using MudBlazor;

namespace MudWind.Services;

public class ThemeManagerConfiguration
{
    public MudTheme Theme { get; init; }
    public string LocalStorageKey { get; init; }
    public bool IsDarkMode { get; init; }
}