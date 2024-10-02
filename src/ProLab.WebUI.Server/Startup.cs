using ProLab.Application.Extensions;
using ProLab.Infrastructure.Extensions;
using ProLab.WebUI.Server.Components;

namespace ProLab.WebUI.Server;
public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddRazorComponents()
            .AddInteractiveServerComponents();

        _ = services.AddApplication();
        _ = services.AddInfrastructure(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            _ = app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            _ = app.UseHsts();
        }

        _ = app.UseHttpsRedirection();
        _ = app.UseStaticFiles();

        _ = app.UseRouting();

        _ = app.UseAntiforgery();

        _ = app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
        });
    }
}
