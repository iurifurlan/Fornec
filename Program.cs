using Microsoft.EntityFrameworkCore;
using Fornec.Data;
    
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Fornec.Data.AppCont>(options =>
{
    options.UseSqlServer(builder
        .Configuration
        .GetConnectionString("DbFornec"));


});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

AppDBInitializer.Seed(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fornecedores}/{action=Index}/{id?}");

app.Run();
