using System.Diagnostics.CodeAnalysis;
using GdscRecruitment.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Data;

public class Repository<T> : IRepository<T> where T : class, IEntity 
{
    private readonly ApplicationDbContext _context;
    public DbSet<T> DbSet { get; set; }

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }

    private Task<int> Save => _context.SaveChangesAsync();
    
    public async Task<T> AddAsync([NotNull] T entity)
    {
        entity.Id = Guid.NewGuid().ToString();
        entity.Created = entity.Updated = DateTime.UtcNow;

        entity = (await DbSet.AddAsync(entity)).Entity;
        await Save;

        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T> GetAsync([NotNull] string id)
    {
        return await DbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T> UpdateAsync([NotNull] string id, [NotNull] T newEntity)
    {
        var entity = await GetAsync(id);
        if (entity is null) return null;

        CheckUpdateObject(entity, newEntity);

        await _context.SaveChangesAsync();

        return DbSet.First(e => e.Id == id);
    }

    public async Task<T>? DeleteAsync([NotNull] string id)
    {
        var entity = await DbSet.FirstOrDefaultAsync(item => item.Id == id);

        if (entity is null) return null;

        entity = DbSet.Remove(entity).Entity;
        await Save;

        return entity;
    }

    public static void CheckUpdateObject(T originalObj, object updateObj)
    {
        foreach (var property in updateObj.GetType().GetProperties())
        {
            var propValue = property.GetValue(updateObj, null);
            var originalProp = originalObj.GetType().GetProperty(property.Name);
            if (propValue is not null && originalProp is not null) originalProp.SetValue(originalObj, propValue);
        }
    }
}