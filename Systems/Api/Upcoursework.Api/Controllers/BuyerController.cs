using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upcoursework.DTOs.AuthorDtos;
using Upcoursework.DTOs.BuyerDtos;
using Upcoursework.Services.Authors.Authors;
using Upcoursework.Services.Buyers.Buyers;
using Upcoursework.Services.Logger.Logger;

namespace Upcoursework.Api.Controllers;
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
public class BuyerController : BaseController
{
    private readonly IAppLogger logger;
    private readonly IBuyerService buyerService;

    public BuyerController(IAppLogger logger, IBuyerService buyerService)
    {
        this.logger = logger;
        this.buyerService = buyerService;
    }
    [HttpGet]
    public async Task<IEnumerable<BuyerResponseDto>> GetAll()
    {
        var result = await buyerService.GetAll();

        return result;
    }
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await buyerService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    // [Authorize(AppScopes.BooksWrite)]
    public async Task<BuyerResponseDto> Create(BuyerRequestDto request)
    {
        var result = await buyerService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, BuyerRequestDto request)
    {
        await buyerService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    //[Authorize(AppScopes.BooksWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await buyerService.Delete(id);
    }
}
