using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CompanyProductBlazor;
using CompanyProductBlazor.Services;
using CompanyProductBlazor.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configuración de la URL base de la API
var apiUrl = builder.Configuration.GetValue<string>("ApiUrl") ?? "https://localhost:7000/api/";

// Registrar HttpClient con la URL base de la API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

// Registrar servicios
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

await builder.Build().RunAsync();