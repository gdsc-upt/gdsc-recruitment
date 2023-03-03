using GdscRecruitment.Common.Features.Examples.Models;
using GdscRecruitment.Common.Features.FieldOptions.Model;
using GdscRecruitment.Common.Features.Fields.Models;
using GdscRecruitment.Common.Features.Responses.Models;
using GdscRecruitment.Common.Features.Teams.Models;
using GdscRecruitment.Common.Features.Users.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GdscRecruitment.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ExampleModel> Examples { get; set; } = null!;

    public DbSet<FieldModel> Fields { get; set; } = null!;

    public DbSet<ResponseModel> Responses { get; set; } = null!;

    public DbSet<FieldOptionsModel> FieldOptions { get; set; } = null!;
    
    public DbSet<TeamModel> Teams { get; set; } = null!;
}
