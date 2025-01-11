using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;

namespace ProLab.App.Features.Couriers;

public interface ICourierService
{
    Task<int> CreateAsync(CreateCourierRequest request);

    Task DeleteAsync(int id);

    Task<GetCourierResponse> GetByIdAsync(int id);

    Task<GetCourierListResponse> GetListAsync(GetCourierListRequest? request = null);

    Task UpdateAsync(int id, UpdateCourierRequest request);
}
