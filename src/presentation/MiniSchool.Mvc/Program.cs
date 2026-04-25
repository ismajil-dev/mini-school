using MiniSchool.Infrastructure.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. MVC-ni qeydiyyatdan keçiririk
builder.Services.AddControllersWithViews();

// 2. FluentValidation-ı zəncirvari YOX, birbaşa IServiceCollection-a əlavə edirik
builder.Services.AddFluentValidationAutoValidation(); // Backend-də ModelState auto-validation üçün
builder.Services.AddFluentValidationClientsideAdapters(); // Frontend-də (jQuery) auto-validation üçün

// 3. Bizim əvvəlki addımda yazdığımız custom extension metod (MediatR, DbContext, Repos, Validators)
builder.Services.AddInfrastructureAndPersistenceServices(builder.Configuration);

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