﻿using ProLab.Api.Common;
using ProLab.Application.Common.Query;
using ProLab.Application.Orders.Commands;
using ProLab.Application.Orders.Query;
using ProLab.Application.Orders.Results;
using ProLab.Domain.Orders;
using ProLab.Shared.Orders.Requests;
using ProLab.Shared.Orders.Response;

namespace ProLab.Api.Features.Orders;

internal static class OrderMappingExtensions
{
    public static CreateOrderCommand ToCommand(this CreateOrderRequest request)
    {
        return new CreateOrderCommand
        {
            Number = request.Number,
            Address = request.Address.ToData(),
            Date = request.Date,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            WarehouseId = request.WarehouseId
        };
    }

    public static UpdateOrderCommand ToCommand(this UpdateOrderRequest request)
    {
        return new UpdateOrderCommand
        {
            Number = request.Number,
            Address = request.Address.ToData(),
            Date = request.Date,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            WarehouseId = request.WarehouseId
        };
    }

    public static QueryParameters<Order> ToQueryParameters(this GetOrderListRequest request)
    {
        return new QueryParameters<Order>
        {
            Filter = request.Filter == null ? null : new OrderFilter
            {
                Search = request.Filter.Search
            },
            Sorting = request.Sorting == null ? null : new OrderSorting
            {
                IsDescending = request.Sorting.IsDescending,
                Sort = request.Sorting.Sort
            },
            Paging = request.Paging?.ToParameters()
        };
    }

    public static GetOrderResponse ToResponse(this OrderResult result)
    {
        return new GetOrderResponse
        {
            Id = result.Id,
            Number = result.Number,
            Address = result.Address.ToData(),
            Date = result.Date,
            StartTime = result.StartTime,
            EndTime = result.EndTime,
            WarehouseId = result.WarehouseId
        };
    }

    public static GetOrderListResponse ToResponse(this OrderListResult result)
    {
        return new GetOrderListResponse
        {
            Items = result.Items.Select(item => new GetOrderListResponse.ItemData
            {
                Id = item.Id,
                Number = item.Number,
                Address = item.Address.ToData(),
                Date = item.Date,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                Warehouse = new GetOrderListResponse.ItemData.WarehouseData
                {
                    Id = item.Warehouse.Id,
                    Name = item.Warehouse.Name
                }
            }),
            TotalCount = result.TotalCount,
            PageSize = result.PageSize,
            CurrentPage = result.CurrentPage
        };
    }
}
