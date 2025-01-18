using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Order:CommonAbstract
{
    public int Id { get; set; }
    public string Address {  get; set; }
    public string Name {  get; set; }
    public decimal TotalAmount { get; set; }
    public string PhoneNumber { get; set; }
    public int Status { get; set; } = 0;
    public int PaymentMethod { get; set; } = 0;
    
    public string? UserId { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public bool IsDeleted { get; set; } = false;

}
