using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pokemon.Data.Interfaces;
using Pokemon.Data.Logic;
using Pokemon.Data.Repositories;
using Pokemon.Data.Services;
using Serilog;
using System;
using System.IO;

namespace Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .CreateLogger();


            Log.Logger.Information("Application starting...");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IPokemonService, PokemonService>();
                    services.AddTransient<IPokemonRepository, PokemonRepository>();
                    services.AddTransient<IPokemonLogic, PokemonLogic>();
                })
                .UseSerilog()
                .Build();

            var service = ActivatorUtilities.CreateInstance<PokemonService>(host.Services);
            service.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();
        }
    }
}
