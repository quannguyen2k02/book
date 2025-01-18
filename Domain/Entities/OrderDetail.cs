using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
[Table("OrderDetail")]
public class OrderDetail:CommonAbstract
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public bool IsDeleted { get; set; } = false;

}
