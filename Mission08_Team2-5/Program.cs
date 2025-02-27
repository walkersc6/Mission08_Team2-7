using Microsoft.EntityFrameworkCore;
using Mission08_Team2_5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskToCompleteContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:TaskDbConnection"]); // allows DbContext to represent the database
});

builder.Services.AddScoped<ITasksRespository, EFTasksRepository>(); // gives each HTTPS request its own instance of the repository
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
