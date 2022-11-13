using System.Diagnostics.CodeAnalysis;
using GdscRecruitment.Base.Entities;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Data;

public interface IRepository<T> where T : class, IEntity 
{
    DbSet<T> DbSet { get; set; }

    Task<T> AddAsync([NotNull] T entity);

    Task<T> GetAsync([NotNull] string id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> UpdateAsync([NotNull] string id, [NotNull] T newEntity);

    Task<T>? DeleteAsync([NotNull] string id);
}