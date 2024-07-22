using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Cursova.Service;
using Cursova.Domain.Repositories.Abstract;
using Cursova.Domain.Repositories.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//Додавання конфігураційногофайлу
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ISalesDealService, SalesDealService>();


//підключення конфігів до класів
builder.Services.Configure<Config>(builder.Configuration.GetSection("Project"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JWTSettings>();
builder.Services.AddSingleton(jwtSettings);

//налаштування джвт токен
builder.Services.AddSingleton(new JWTService(jwtSettings.Secret, jwtSettings.Issuer, jwtSettings.Audience));

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddControllers();



//бд
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
