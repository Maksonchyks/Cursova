using Microsoft.EntityFrameworkCore;
using Cursova.Service;
using Cursova.Domain.Repositories.Abstract;
using Cursova.Domain.Repositories.EntityFramework;


var builder = WebApplication.CreateBuilder(args);


//Додавання конфігураційногофайлу
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ISalesDealService, SalesDealService>();
builder.Services.Configure<Config>(builder.Configuration.GetSection("Project"));


var connectionString = builder.Configuration.GetSection("Project").GetValue<string>("ConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


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
