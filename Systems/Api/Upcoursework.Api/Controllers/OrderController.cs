using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Upcoursework.DTOs.OrderDtos;
using Upcoursework.Services.Logger.Logger;
using Upcoursework.Services.Orders.Orders;

namespace Upcoursework.Api.Controllers;
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
public class OrderController : BaseController
{
    private readonly IAppLogger logger;
    private readonly IOrderService orderService;

    public OrderController(IAppLogger logger, IOrderService orderService)
    {
        this.logger = logger;
        this.orderService = orderService;
    }
    [HttpGet]
    public async Task<IEnumerable<OrderGetDto>> GetAll()
    {
        var result = await orderService.GetAll();

        return result;
    }
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await orderService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    // [Authorize(AppScopes.BooksWrite)]
    public async Task<OrderGetDto> Create(OrderCreateDto request)
    {
        var result = await orderService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, OrderCreateDto request)
    {
        await orderService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    //[Authorize(AppScopes.BooksWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await orderService.Delete(id);
    }
}
