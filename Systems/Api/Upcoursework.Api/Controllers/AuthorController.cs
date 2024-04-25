using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Upcoursework.Common.Exceptions;
using Upcoursework.DTOs.AuthorDtos;
using Upcoursework.Services.Authors.Authors;
using Upcoursework.Services.Logger.Logger;

namespace Upcoursework.Api.Controllers;
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
public class AuthorController : BaseController
{
    private readonly IAppLogger logger;
    private readonly IAuthorService authorService;

    public AuthorController(IAppLogger logger, IAuthorService authorService)
    {
        this.logger = logger;
        this.authorService = authorService;
    }

    [HttpGet]
    public async Task<IEnumerable<AuthorGetDto>> GetAll()
    {
        var result = await authorService.GetAll();

        return result;
    }
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await authorService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    // [Authorize(AppScopes.BooksWrite)]
    public async Task<AuthorGetDto> Create(AuthorCreateDto request)
    {
        var result = await authorService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    public async Task Update([FromRoute] Guid id, AuthorUpdateDto request)
    {
        await authorService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    //[Authorize(AppScopes.BooksWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await authorService.Delete(id);
    }
}
