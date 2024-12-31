using FastEndpoints;
using FastEndpoints.Swagger;
using ProLab.Api.Core;
using ProLab.Application.Extensions;
using ProLab.Infrastructure.Extensions;

namespace ProLab.Api;

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
        _ = services.AddFastEndpoints();
        _ = services.SwaggerDocument();

        _ = services.AddApplication();
        _ = services.AddInfrastructure(Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            _ = app.UseSwaggerGen();
        }

        _ = app.UseMiddleware<GlobalExceptionMiddleware>();

        _ = app.UseHttpsRedirection();

        _ = app.UseRouting();
        _ = app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapFastEndpoints(c =>
            {
                c.Endpoints.RoutePrefix = "api";
                c.Errors.UseProblemDetails();
            });
        });
    }
}

