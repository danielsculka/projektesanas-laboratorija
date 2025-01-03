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
        _ = services.SwaggerDocument(options =>
        {
            options.ShortSchemaNames = true;
            options.DocumentSettings = settings =>
            {
                settings.Title = "API";
                settings.Version = "V1";
            };
        });

        _ = services.AddApplication();
        _ = services.AddInfrastructure(Configuration);

        _ = services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                _ = policy
                    .WithOrigins(Configuration["App:Url"]!)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            _ = app.UseSwaggerGen(uiConfig: config =>
            {
                config.Path = Configuration["Swagger:Path"]!;
            });
        }

        _ = app.UseMiddleware<GlobalExceptionMiddleware>();

        _ = app.UseHttpsRedirection();

        _ = app.UseRouting();

        _ = app.UseCors();

        _ = app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapFastEndpoints(config =>
            {
                config.Endpoints.RoutePrefix = "api";
                config.Endpoints.ShortNames = true;
                config.Errors.UseProblemDetails();
            });
        });
    }
}

