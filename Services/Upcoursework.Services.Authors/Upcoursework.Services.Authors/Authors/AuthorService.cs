using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Upcoursework.Common.Exceptions;
using Upcoursework.Common.Validator;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.DTOs.AuthorDtos;

namespace Upcoursework.Services.Authors.Authors;
public class AuthorService : IAuthorService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<AuthorCreateDto> createModelValidator;
    private readonly IModelValidator<AuthorUpdateDto> updateModelValidator;

    public AuthorService(
        IDbContextFactory<MainDbContext> dbContextFactory, 
        IMapper mapper,
        IModelValidator<AuthorCreateDto> createModelValidator,
        IModelValidator<AuthorUpdateDto> updateModelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
        this.updateModelValidator = updateModelValidator;
    }

    public async Task<IEnumerable<AuthorGetDto>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var author = await context.Authors
            .Include(x => x.Feedback)
            .Include(x => x.Skills)
            .Include(x => x.Subjects)
            .Include(x => x.Orders)
            .ToListAsync();

        var result = mapper.Map<IEnumerable<AuthorGetDto>>(author);

        return result;
    }
    public async Task<AuthorGetDto> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var author = await context.Authors
            .Include(x => x.Feedback)
            .Include(x => x.Skills)
            .Include(x => x.Subjects)
            .Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<AuthorGetDto>(author);

        return result;
    }

    public async Task<AuthorGetDto> Create(AuthorCreateDto model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var author = mapper.Map<Author>(model);

        context.AttachRange(author);
        await context.Authors.AddAsync(author);
        await context.SaveChangesAsync();

        //await action.PublicateBook(new PublicateBookModel()
        //{
        //    Id = book.Id,
        //    Title = book.Title,
        //    Description = book.Description
        //});

        return mapper.Map<AuthorGetDto>(author);
    }

    public async Task Update(Guid id, AuthorUpdateDto model)
    {
        await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var author = await context.Authors.Where(x => x.Uid == id)
            .Include(x => x.Orders)
            .Include(x => x.Comments).FirstOrDefaultAsync();

        author = mapper.Map(model, author);
        context.Attach(author);
        context.Authors.Update(author);

        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var author = await context.Authors.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (author == null)
            throw new ProcessException($"Author (ID = {id}) not found.");

        context.Authors.Remove(author);

        await context.SaveChangesAsync();
    }
}
