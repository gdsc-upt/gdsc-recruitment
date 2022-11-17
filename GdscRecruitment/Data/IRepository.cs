using System.Diagnostics.CodeAnalysis;
using GdscRecruitment.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Data;

public interface IRepository<T> where T : class, IModel
{
    DbSet<T> DbSet { get; init; }

    Task<T> AddAsync([NotNull] T entity);

    Task<T?> GetAsync(string id);

    Task<IEnumerable<T>> GetAsync();

    Task<T?> UpdateAsync(string id, object newEntity);
    Task<T?> UpdateAsync(T entity);

    Task<T?> DeleteAsync(string id);
}
