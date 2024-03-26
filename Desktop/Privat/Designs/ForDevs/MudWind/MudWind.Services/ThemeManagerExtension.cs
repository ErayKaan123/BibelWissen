using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;

namespace MudWind.Services;

public static class ThemeManagerExtension
{
    public static void AddThemeServices(this IServiceCollection services, ThemeManagerConfiguration configuration)
    {
        services.AddBlazoredLocalStorage();
        services.AddScoped<ThemeManager>(x =>
        {
            var localStorage = x.GetService<ILocalStorageService>();

            return new ThemeManager(localStorage, configuration);
        });
    }
}