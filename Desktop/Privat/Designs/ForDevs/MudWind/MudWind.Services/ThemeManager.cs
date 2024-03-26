using Blazored.LocalStorage;
using MudBlazor;

namespace MudWind.Services;

public class ThemeManager
{
    private readonly ThemeManagerConfiguration _configuration;
    private readonly string _localStorageKey;

    private readonly ILocalStorageService _localStorageService;
    public readonly MudTheme Theme;
    public MudThemeProvider Provider = new();

    public ThemeManager(ILocalStorageService localStorageService, ThemeManagerConfiguration configuration)
    {
        _localStorageService = localStorageService;
        Theme = configuration.Theme;
        _localStorageKey = configuration.LocalStorageKey;
        _configuration = configuration;
        _ = Task.Run(TrySetThemeByLocalStorage);
    }

    public event Action? OnThemeChanged;
    public Palette CurrentPalette => (Provider.IsDarkMode) ? Theme.PaletteDark : Theme.Palette;

    public async Task Toggle()
    {
        Provider.IsDarkMode = !Provider.IsDarkMode;
        await _localStorageService.SetItemAsync(_localStorageKey, Provider.IsDarkMode);
        OnThemeChanged?.Invoke();
    }

    private async Task TrySetThemeByLocalStorage()
    {
        var hasStorage = await _localStorageService.ContainKeyAsync(_localStorageKey);
        if (hasStorage)
            try
            {
                Provider.IsDarkMode = await _localStorageService.GetItemAsync<bool>(_localStorageKey);
                OnThemeChanged?.Invoke();
            }
            catch (Exception e)
            {
                Provider.IsDarkMode = false;
            }
        else
            Provider.IsDarkMode = _configuration.IsDarkMode;
    }
}