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
using Upcoursework.DTOs.OrderDtos;

namespace Upcoursework.Services.Orders.Orders;
public class OrderService : IOrderService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<OrderCreateDto> modelValidator;

    public OrderService(IDbContextFactory<MainDbContext> dbContextFactory, IMapper mapper, IModelValidator<OrderCreateDto> modelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.modelValidator = modelValidator;
    }

    public async Task<OrderGetDto> Create(OrderCreateDto model)
    {
        await modelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var order = mapper.Map<Order>(model);

        context.AttachRange(order);
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();

        //await action.PublicateBook(new PublicateBookModel()
        //{
        //    Id = book.Id,
        //    Title = book.Title,
        //    Description = book.Description
        //});

        return mapper.Map<OrderGetDto>(order);
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var order = await context.Orders.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (order == null)
            throw new ProcessException($"Order (ID = {id}) not found.");

        context.Orders.Remove(order);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderGetDto>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var orders = await context.Orders
            .Include(x => x.Author)
            .Include(x => x.Buyer)
            .Include(x => x.SkillsRequired)
            .Include(x => x.Subject)
            .ToListAsync();

        var result = mapper.Map<IEnumerable<OrderGetDto>>(orders);

        return result;
    }

    public async Task<OrderGetDto> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var order = await context.Orders
            .Include(x => x.Author)
            .Include(x => x.Buyer)
            .Include(x => x.SkillsRequired)
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<OrderGetDto>(order);

        return result;
    }

    public async Task Update(Guid id, OrderCreateDto model)
    {
        await modelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var order = await context.Orders.Where(x => x.Uid == id)
            .Include(x => x.Author)
            .Include(x => x.Buyer)
            .Include(x => x.SkillsRequired)
            .Include(x => x.Subject)
            .FirstOrDefaultAsync();

        order = mapper.Map(model, order);
        context.Attach(order);
        context.Orders.Update(order);

        await context.SaveChangesAsync();
    }
}
