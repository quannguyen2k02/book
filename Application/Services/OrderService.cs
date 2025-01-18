using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork,IMapper mapper )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<OrderDTO> CreateOrder(CreateRequestOrder request)
    {
        var order = new Order
        {
            OrderDetails = new List<OrderDetail>(),
            TotalAmount = 0,
            Address = request.Address,
            PhoneNumber = request.Phone,
            Name = request.Name
        };
        foreach(var item in request.OrderItems)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(item.BookID);
            if (book == null || book.IsDeleted) throw new KeyNotFoundException($"Product with id {item.BookID} not found!");
            var orderDetail = new OrderDetail
            {
                BookId = item.BookID,
                Quantity = item.Quantity,
                UnitPrice = book.PriceSale
                
            };
            order.OrderDetails.Add(orderDetail);
            order.TotalAmount += orderDetail.TotalPrice;
        }
        var result = await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.Complete();
        var orderDTO = _mapper.Map<OrderDTO>(result);
        return orderDTO;

    }

    public async Task<List<OrderDTO>> GetAllOrdersAsync()
    {
        var orders = await _unitOfWork.Orders.GetOrdersAndOrderDetails();
        return _mapper.Map<List<OrderDTO>>(orders);
    }
}
