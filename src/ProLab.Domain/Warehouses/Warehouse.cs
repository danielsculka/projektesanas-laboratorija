using ProLab.Domain.Addresses;
using ProLab.Domain.Orders;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Warehouses;

public class Warehouse : Entity<Guid>
{
    [MaxLength(50)]
    public required string Name { get; set; }

    public required Address Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
