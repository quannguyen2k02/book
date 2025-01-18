using Domain.Entities;

namespace Domain.Models
{
    public class OrderDTO:CommonAbstract
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public int PaymentMethod { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}
