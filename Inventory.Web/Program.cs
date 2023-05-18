using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventory.Repository;
using Inventory.Models;
using Inventory.Utility.HelperClass;
using Inventory.Repository.BillTypeServices;
using Inventory.Repository.CustomerTypess;
using Inventory.Repository.VendorTypeService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RepositoryConnection") ?? throw new InvalidOperationException("Connection string 'RepositoryConnection' not found.");

builder.Services.AddDbContext<Inventory.Repository.ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Inventory.Repository.ApplicationDBContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IBillTypeRepo, BillTypeRepo>();
builder.Services.AddTransient<ICustomerTypeRepo, CustomerTypeRepo>();
builder.Services.AddTransient<IVendorTypeRepo, VendorTypeRepo>();
builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
