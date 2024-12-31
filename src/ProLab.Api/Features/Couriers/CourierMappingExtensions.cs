using ProLab.Api.Features.Couriers.Create;
using ProLab.Api.Features.Couriers.GetList;
using ProLab.Api.Features.Couriers.Update;
using ProLab.Application.Common.Query;
using ProLab.Application.Couriers.Commands;
using ProLab.Domain.Couriers;

namespace ProLab.Api.Features.Couriers;

internal static class CourierMappingExtensions
{
    public static CreateCourierCommand ToCommand(this CreateCourierRequest request)
    {
        return new CreateCourierCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }

    public static UpdateCourierCommand ToCommand(this UpdateCourierRequest request)
    {
        return new UpdateCourierCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
    }

    public static QueryParameters<Courier> ToQueryParameters(this GetCourierListRequest request)
    {
        return new QueryParameters<Courier>
        {
            Filter = request.Filter,
            Sorting = request.Sorting,
            Paging = request.Paging
        };
    }
}
