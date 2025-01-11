using Microsoft.AspNetCore.Components;
using ProLab.Shared.RouteSets;
using Radzen;

namespace ProLab.App.Features.RouteSets.Dialogs;

public class RouteSetGenerateDialogBase : ComponentBase
{
    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    public IRouteSetService RouteSetService { get; set; }

    public GenerateRouteSetRequest RouteSet { get; set; } = new GenerateRouteSetRequest
    {
        Date = DateOnly.FromDateTime(DateTime.Now),
        StartTime = new TimeOnly(8, 0),
        EndTime = new TimeOnly(17, 0),
    };

    protected void Cancel()
    {
        DialogService.Close(false);
    }

    protected async Task Generate()
    {
        await RouteSetService.GenerateAsync(RouteSet);

        DialogService.Close(true);
    }
}
