using ProLab.Domain.Addresses;
using ProLab.Domain.Warehouses;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Orders;

public class Order : Entity<Guid>
{
    [MaxLength(50)]
    public required string Number { get; set; }

    public required Address Address { get; set; }

    public Guid WarehouseId { get; set; }
    public virtual required Warehouse Warehouse { get; set; }
}
