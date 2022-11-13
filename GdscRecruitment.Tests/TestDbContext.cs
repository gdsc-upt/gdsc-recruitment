using GdscRecruitment.Base.Models;
using GdscRecruitment.Data;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Tests;

public class TestDbContext<T> where T : class, IModel
{
    public TestDbContext(IEnumerable<T>? testData = null)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(nameof(T) + "-Database-" + Guid.NewGuid())
           .EnableDetailedErrors()
           .EnableSensitiveDataLogging()
           .Options;

        Object = new ApplicationDbContext(options);

        if (testData is null)
        {
            return;
        }

        Object.Set<T>().AddRange(testData);
        Object.SaveChanges();
    }

    public ApplicationDbContext Object { get; }
}
