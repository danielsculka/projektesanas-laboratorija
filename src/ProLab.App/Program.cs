using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProLab.App;
using ProLab.App.Features.Couriers;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5172")
});

builder.Services.AddScoped<ICourierService, CourierService>();

builder.Services.AddRadzenComponents();

await builder
    .Build()
    .RunAsync();
