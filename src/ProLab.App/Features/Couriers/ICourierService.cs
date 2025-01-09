using ProLab.Shared.Couriers.Request;
using ProLab.Shared.Couriers.Response;

namespace ProLab.App.Features.Couriers;

public interface ICourierService
{
    Task<GetCourierListResponse?> GetListAsync(GetCourierListRequest? request = null);
    Task<int> CreateAsync(CreateCourierRequest request);
    Task<int> UpdateAsync(int id, UpdateCourierRequest request);
    Task<int> DeleteAsync(int id);
}
