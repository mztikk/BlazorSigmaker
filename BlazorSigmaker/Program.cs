using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorSigmaker.AoB;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSigmaker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder
                .Services
                .AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddSingleton<IAobGenerator, AobGenerator>()
                .AddSingleton<IAobValidator, AobValidator>()
                .AddSingleton<IAobPrettifier, AobPrettifier>();

            await builder.Build().RunAsync();
        }
    }
}
