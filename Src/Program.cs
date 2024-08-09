using Microsoft.EntityFrameworkCore;
using NorwegianRowingAssociation.Infrastructure;
using NorwegianRowingAssociation.Infrastructure.Repositories;
using NorwegianRowingAssociation.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddRazorPages();

builder.Services.AddSession(o =>
{
	o.IdleTimeout = TimeSpan.FromHours(12);
	o.Cookie.Name = ".AspNetCore.Session.NorwegianRowingAssociation";
	o.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<NorwegianRowingAssociationContext>(o =>
	o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).EnableDetailedErrors()
);

builder.Services.AddScoped<IGenericRepository<Test>, TestRepository>();
builder.Services.AddScoped<IGenericRepository<TestResult>, TestResultRepository>();
builder.Services.AddScoped<IGenericRepository<TestWeek>, TestWeekRepository>();
builder.Services.AddScoped<IGenericRepository<UserClass>, UserClassRepository>();
builder.Services.AddScoped<IGenericRepository<UserClub>, UserClubRepository>();
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IGenericRepository<UserRole>, UserRoleRepository>();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

await app.RunAsync();
