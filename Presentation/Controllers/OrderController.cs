using Application.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(CreateRequestOrder request)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var order = await _orderService.CreateOrder(request);
                return Ok(order);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        return BadRequest(ModelState);
    }
    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }
}
