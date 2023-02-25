using GdscRecruitment.Common.Features.Examples.Models;
using GdscRecruitment.Common.Features.Users.Models;
using GdscRecruitment.Features.FieldOptions.Model;
using GdscRecruitment.Features.Fields.Models;
using GdscRecruitment.Features.Responses.Models;
using GdscRecruitment.Features.Teams.Models;
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
