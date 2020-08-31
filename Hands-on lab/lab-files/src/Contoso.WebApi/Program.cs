using Contoso.Azure.KeyVault;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Contoso.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var buildConfig = config.Build();

                config.AddEnvironmentVariables();

                // ******************************************
                // TODO #1: Insert code into this block to create a connection to Azure Key Vault.
                //config.// Add the appropriate "Add" statement and insert the requried Key Vault configuration settings
                // ******************************************
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                });

    }
}