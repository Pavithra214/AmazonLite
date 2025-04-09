using AmazonLite;
using AmazonLite.Helper;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

//LOCALIZATION
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
           .AddViewLocalization();
//Define supported cultures
var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("ta-IN")
};
//Apply Localization Middleware
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures

};


//ENTITY FRAMEWORK
var connection = builder.Configuration.GetConnectionString("JSconn");
builder.Services.AddDbContext<AppDBContext>(options=>options.UseSqlServer(connection));

//DEPENDENCY INJECTION
builder.Services.AddTransient<IMathLogic,MathLogic>();


var app=builder.Build();

//TO Access the wwwroot files and folders
app.UseStaticFiles();

//To access the Localiztaion
app.UseRequestLocalization(localizationOptions);

//To Configure Routing
app.UseRouting();
app.MapControllerRoute(
name: "default",
pattern: "{Controller=Home}/{action=Index}/{id?}");


//To make the application run
app.Run();   