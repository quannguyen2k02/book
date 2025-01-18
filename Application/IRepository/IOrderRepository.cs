using Domain.Entities;
using Domain.Models;

namespace Application.IRepository;

public interface IOrderRepository:IGenericRepository<Order>
{
    public Task<List<Order>> GetOrdersAndOrderDetails();
}
