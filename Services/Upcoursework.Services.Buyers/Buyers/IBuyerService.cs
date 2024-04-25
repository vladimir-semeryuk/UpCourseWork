using Upcoursework.DTOs.BuyerDtos;

namespace Upcoursework.Services.Buyers.Buyers;
public interface IBuyerService
{
    Task<IEnumerable<BuyerResponseDto>> GetAll();
    Task<BuyerResponseDto> GetById(Guid id);
    Task<BuyerResponseDto> Create(BuyerRequestDto model);
    Task Update(Guid id, BuyerRequestDto model);
    Task Delete(Guid id);
}
