using Domain.Entities;

namespace Domain.Models
{
    public class OrderDTO:CommonAbstract
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public int PaymentMethod { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
