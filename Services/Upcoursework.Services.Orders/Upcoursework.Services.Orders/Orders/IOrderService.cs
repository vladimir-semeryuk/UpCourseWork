using Upcoursework.DTOs.OrderDtos;

namespace Upcoursework.Services.Orders.Orders;
public interface IOrderService
{
    Task<IEnumerable<OrderGetDto>> GetAll();
    Task<OrderGetDto> GetById(Guid id);
    Task<OrderGetDto> Create(OrderCreateDto model);
    Task Update(Guid id, OrderCreateDto model);
    Task Delete(Guid id);
}
