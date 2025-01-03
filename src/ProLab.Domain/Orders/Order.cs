using ProLab.Domain.Addresses;
using ProLab.Domain.Warehouses;
using System.ComponentModel.DataAnnotations;

namespace ProLab.Domain.Orders;

public class Order : Entity<int>
{
    [Required]
    [MaxLength(50)]
    public string Number { get; set; }

    [Required]
    public Address Address { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
}
