using ProLab.Shared.Warehouses.Requests;
using ProLab.Shared.Warehouses.Response;

namespace ProLab.App.Features.Warehouses;

public interface IWarehouseService
{
    Task<int> CreateAsync(CreateWarehouseRequest request);

    Task DeleteAsync(int id);

    Task<GetWarehouseResponse> GetByIdAsync(int id);

    Task<GetWarehouseListResponse> GetListAsync(GetWarehouseListRequest? request = null);

    Task UpdateAsync(int id, UpdateWarehouseRequest request);
}
