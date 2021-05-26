using BlazorBattles.Client.Services;
using BlazorBattles.Client.Services.ApplesService;
using BlazorBattles.Client.Services.AuthService;
using BlazorBattles.Client.Services.LeaderboardService;
using BlazorBattles.Client.Services.LeaderBoardService;
using BlazorBattles.Client.Services.UnitService;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBattles.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IBananaService, BananaService>();
            builder.Services.AddScoped<IApplesService, ApplesService>();
            builder.Services.AddScoped<IUnitService, UnitService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();

            await builder.Build().RunAsync();
        }
    }
}
