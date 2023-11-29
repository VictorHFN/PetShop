using Microsoft.EntityFrameworkCore;
using PetShop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    // SQLServer
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    // PostgreSQL
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

// Rota específica para o controlador 'Animal' e a ação 'Index'
app.MapControllerRoute(
    name: "IndexAnimal",
    pattern: "Animal/Index",
    defaults: new { controller = "Animal", action = "Index" });

app.MapControllerRoute(
    name: "EditarAnimal",
    pattern: "Animal/Editar/{id}",
    defaults: new { controller = "Animal", action = "Editar" });

app.MapControllerRoute(
    name: "CadastrarAnimal",
    pattern: "Animal/Cadastrar",
    defaults: new { controller = "Animal", action = "Cadastrar" });

// Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
