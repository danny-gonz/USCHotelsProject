using Microsoft.Extensions.Options;
using System.Net.Http;
using USCHotelsProject.AppSettings;
using USCHotelsProject.Services;
using USCHotelsProject.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

//Register Services
builder.Services.AddSingleton<IHotelService,HotelService>();


//Register AppKeys
builder.Services.Configure<HotelConfigKeys>(builder.Configuration.GetSection("HotelConfigKeys"));


//Register IHttpFactoryClient

builder.Services.AddHttpClient("hotelRapidApi", (serviceProvider, client) =>
{
    var settings= serviceProvider.GetRequiredService<IOptions<HotelConfigKeys>>().Value;
    client.DefaultRequestHeaders.Add("X-RapidAPI-Key", settings.RapidApiKey);
    client.DefaultRequestHeaders.Add("X-RapidAPI-Host", settings.RapidHostUrl);
    client.BaseAddress = new Uri(settings.RapidApiBaseUrl);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
