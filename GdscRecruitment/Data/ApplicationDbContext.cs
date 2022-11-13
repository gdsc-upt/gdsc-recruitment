using GdscRecruitment.Auth;
using GdscRecruitment.Features.Example;
using GdscRecruitment.Features.Forms;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GdscRecruitment.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ExampleModel> Examples { get; set; }
    
    public DbSet<FieldModel> Fields { get; set; }
    
    public DbSet<ResponseModel> Responses { get; set; }
}
