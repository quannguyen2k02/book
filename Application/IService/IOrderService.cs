using Domain.Models;
namespace Application.IService;

public interface IOrderService 
{
    public Task<OrderDTO> CreateOrder(CreateRequestOrder request);
    public Task<List<OrderDTO>> GetAllOrdersAsync();
}
