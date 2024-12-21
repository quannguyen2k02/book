﻿using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Order:CommonAbstract
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public int Status { get; set; }
    public int PaymentMethod { get; set; }
    [JsonIgnore]

    public ICollection<OrderDetail> OrderDetails { get; set; }
    public bool IsDeleted { get; set; }

}