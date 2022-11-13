using System.Diagnostics.CodeAnalysis;
using GdscRecruitment.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Data;

public interface IRepository<T> where T : class, IModel
{
    DbSet<T> DbSet { get; set; }

    Task<T> AddAsync([NotNull] T entity);

    Task<T?> GetAsync([NotNull] string id);

    Task<IEnumerable<T>> GetAsync();

    Task<T> UpdateAsync([NotNull] string id, [NotNull] object newEntity);

    Task<T> DeleteAsync([NotNull] string id);
}
