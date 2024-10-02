using ProLab.WebUI.Server.Extensions;

namespace ProLab.WebUI.Server;
public class Program
{
    public static void Main(string[] args) =>
        CreateHostBuilder(args)
            .Build()
            .UpdateDatabase()
            .Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => _ = webBuilder.UseStartup<Startup>());
}
