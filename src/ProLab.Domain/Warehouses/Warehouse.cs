using ProLab.Domain.Addresses;
using ProLab.Domain.Orders;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Warehouses;

public class Warehouse : Entity<int>
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public Address Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
