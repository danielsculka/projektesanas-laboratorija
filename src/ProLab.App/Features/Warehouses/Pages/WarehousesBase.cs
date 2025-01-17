﻿using Microsoft.AspNetCore.Components;
using ProLab.App.Features.Warehouses.Dialogs;
using ProLab.Shared.Common;
using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;
using Radzen;
using Radzen.Blazor;

namespace ProLab.App.Features.Warehouses.Pages;

public class WarehousesBase : ComponentBase
{
    [Inject]
    public required IWarehouseService WarehouseService { get; set; }

    [Inject]
    public required DialogService DialogService { get; set; }

    protected RadzenDataGrid<GetWarehouseListResponse.ItemData> Grid;

    public bool IsLoading = false;

    public IEnumerable<GetWarehouseListResponse.ItemData> Items;
    public int Count = 0;
    public int PageSize = 10;

    public async Task LoadData(LoadDataArgs args)
    {
        IsLoading = true;

        await Task.Yield();

        var request = new GetWarehouseListRequest
        {
            Paging = new PagingData
            {
                CurrentPage = args.Skip.HasValue ? args.Skip.Value / PageSize + 1 : 1,
                PageSize = PageSize
            }
        };

        GetWarehouseListResponse pagedList = await WarehouseService.GetListAsync(request);

        Items = pagedList.Items;
        Count = pagedList.TotalCount;

        IsLoading = false;
    }

    public async Task OnAdd()
    {
        bool? result = await DialogService.OpenAsync<WarehouseCreateDialog>("Create warehouse");

        if (result.HasValue && result.Value)
            await Grid.RefreshDataAsync();
    }

    public async Task OnEdit(GetWarehouseListResponse.ItemData warehouse)
    {
        bool? result = await DialogService.OpenAsync<WarehouseUpdateDialog>(
            "Update warehouse",
            new Dictionary<string, object>
            {
                { "WarehouseId", warehouse.Id }
            });

        if (result.HasValue && result.Value)
            await Grid.RefreshDataAsync();
    }

    public async Task OnDelete(GetWarehouseListResponse.ItemData warehouse)
    {
        var result = await DialogService.Confirm(
            "Are you sure?",
            "Delete warehouse",
            new ConfirmOptions()
            {
                OkButtonText = "Yes",
                CancelButtonText = "No"
            });

        if (result.HasValue && result.Value)
        {
            await WarehouseService.DeleteAsync(warehouse.Id);

            await Grid.RefreshDataAsync();
        }
    }
}

