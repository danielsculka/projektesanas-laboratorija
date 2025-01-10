using Microsoft.AspNetCore.Components;
using ProLab.Shared.Common;

namespace ProLab.App.Shared.Components;

public class AddressFormBase : ComponentBase
{
    [Parameter]
    public AddressData Address { get; set; }

    [Parameter]
    public EventCallback<AddressData> AddressChanged { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Address ??= new AddressData();
        Address.Location ??= new CoordinateData();

        await AddressChanged.InvokeAsync(Address);
    }
}
