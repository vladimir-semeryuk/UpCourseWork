using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Common.Exceptions;
using Upcoursework.Common.Validator;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities;
using Upcoursework.DTOs.AuthorDtos;
using Upcoursework.DTOs.BuyerDtos;

namespace Upcoursework.Services.Buyers.Buyers;
public class BuyerService : IBuyerService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<BuyerRequestDto> modelValidator;

    public BuyerService(IDbContextFactory<MainDbContext> dbContextFactory, IMapper mapper, IModelValidator<BuyerRequestDto> modelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.modelValidator = modelValidator;
    }

    public async Task<BuyerResponseDto> Create(BuyerRequestDto model)
    {
        await modelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var buyer = mapper.Map<Buyer>(model);

        context.AttachRange(buyer);
        await context.Buyers.AddAsync(buyer);
        await context.SaveChangesAsync();

        //await action.PublicateBook(new PublicateBookModel()
        //{
        //    Id = book.Id,
        //    Title = book.Title,
        //    Description = book.Description
        //});

        return mapper.Map<BuyerResponseDto>(buyer);
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var buyer = await context.Buyers.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (buyer == null)
            throw new ProcessException($"Buyer (ID = {id}) not found.");

        context.Buyers.Remove(buyer);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<BuyerResponseDto>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var buyers = await context.Buyers
            .Include(x => x.Orders)
            .Include(x => x.Comments)
            .Include(x => x.Feedback)
        .ToListAsync();

        var result = mapper.Map<IEnumerable<BuyerResponseDto>>(buyers);

        return result;
    }

    public async Task<BuyerResponseDto> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var buyer = await context.Buyers
            .Include(x => x.Orders)
            .Include(x => x.Comments)
            .Include(x => x.Feedback)
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<BuyerResponseDto>(buyer);

        return result;
    }

    public async Task Update(Guid id, BuyerRequestDto model)
    {
        await modelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var buyer = await context.Buyers.Where(x => x.Uid == id)
            .Include(x => x.Orders)
            .Include(x => x.Comments)
            .Include(x => x.Feedback)
            .FirstOrDefaultAsync();

        buyer = mapper.Map(model, buyer);
        context.Attach(buyer);
        context.Buyers.Update(buyer);

        await context.SaveChangesAsync();
    }
}
