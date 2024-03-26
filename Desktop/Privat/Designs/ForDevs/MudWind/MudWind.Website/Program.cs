using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudWind.Website;
using MudBlazor.Services;
using MudWind.Services;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddThemeServices(new ThemeManagerConfiguration
{
     Theme = Resources.Theme,
     LocalStorageKey = Resources.LocalStorageKey,
     IsDarkMode = true
});
await builder.Build().RunAsync();