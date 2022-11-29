using GdscRecruitment.Common.Features.Examples.Models;
using GdscRecruitment.Common.Features.Users.Models;
using GdscRecruitment.Features.Fields.Models;
using GdscRecruitment.Features.Responses.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ExampleModel> Examples { get; set; } = null!;

    public DbSet<FieldModel> Fields { get; set; } = null!;

    public DbSet<ResponseModel> Responses { get; set; } = null!;
}
