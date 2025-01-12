using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProLab.App;
using ProLab.App.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

_ = builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.IsDevelopment() ? "https://localhost:5172" : builder.HostEnvironment.BaseAddress),
    Timeout = TimeSpan.FromSeconds(600)
});

builder.Services.AddApp(builder.Configuration);

await builder
    .Build()
    .RunAsync();
