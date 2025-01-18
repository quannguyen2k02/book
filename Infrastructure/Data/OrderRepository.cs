using Application.IRepository;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetOrdersAndOrderDetails()
    {
        var orders = await _context.Orders.Include(o=>o.OrderDetails).ToListAsync();
        return orders;
    }
}
