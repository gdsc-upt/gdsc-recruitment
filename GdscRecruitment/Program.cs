using System.Security.Claims;
using GdscRecruitment.Areas.Identity;
using GdscRecruitment.Common;
using GdscRecruitment.Common.Features.Examples;
using GdscRecruitment.Common.Features.Users.Models;
using GdscRecruitment.Common.Utilities;
using GdscRecruitment.Data;
using GdscRecruitment.Features.FieldOptions;
using GdscRecruitment.Features.Fields;
using GdscRecruitment.Features.Responses;
using GdscRecruitment.Utilities;
using GdscRecruitment.Utilities.Mappers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;
var connectionString = configuration.GetConnectionString("Default");

services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
services.AddDatabaseDeveloperPageExceptionFilter();

var identityBuilder = services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true);
identityBuilder.AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

services.AddRazorPages();
services.AddServerSideBlazor();
services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
services.AddAutoMapper(typeof(MappingProfiles));

services.AddGdscRecruitmentCommon();
services.AddScoped<DbContext, ApplicationDbContext>();
services.AddScoped<ExamplesService>();
services.AddScoped<FieldsService>();
services.AddScoped<ResponsesService>();
services.AddScoped<FieldOptionsService>();
services.AddScoped(typeof(ViewModelHelper<>));
services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();
services.AddTransient<UserManager<User>>();

services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = configuration["Google:ClientId"];
    options.ClientSecret = configuration["Google:ClientSecret"];
    options.ClaimActions.MapJsonKey(CustomClaimTypes.Picture, "picture", "url");
    options.ClaimActions.MapJsonKey(CustomClaimTypes.EmailVerified, "verified_email", "bool");
    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name", "string");
    options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name", "string");
    options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name", "string");
    options.ClaimActions.Add(new CustomClaimAction("list json data", "json data"));
});

var app = builder.Build();

app.MigrateIfNeeded();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
