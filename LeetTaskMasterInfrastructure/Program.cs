using LeetTaskMasterInfrastructure.Interface;
using LeetTaskMasterInfrastructure.Context;
using LeetTaskMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure app configuration
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Create DbContext with configuration
builder.Services.AddDbContext<IDataContext<LeetTask>, LeetTaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<LeetTaskDbContext>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new LeetTaskDbContext(configuration);
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
