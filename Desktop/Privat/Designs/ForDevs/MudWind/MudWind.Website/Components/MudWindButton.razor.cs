using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;

namespace MudWind.Website.Components;

public partial class MudWindButton
{
    private string ClassBuilder => new CssBuilder()
        .AddClass(Class)
        .AddClass("mud-typography-body1")
        .AddClass("font-[430]")
        .AddClass("rounded-md")
        .Build();
}