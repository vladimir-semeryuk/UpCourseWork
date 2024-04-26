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
using Upcoursework.DTOs.CommentDtos;

namespace Upcoursework.Services.Comments.Comments;
public class CommentService : ICommentService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CommentCreateDto> createModelValidator;

    public CommentService(IDbContextFactory<MainDbContext> dbContextFactory, 
                          IMapper mapper, IModelValidator<CommentCreateDto> createModelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
    }

    public async Task<CommentGetDto> Create(CommentCreateDto model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var comment = mapper.Map<Comment>(model);

        context.AttachRange(comment);
        await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();

        //await action.PublicateBook(new PublicateBookModel()
        //{
        //    Id = book.Id,
        //    Title = book.Title,
        //    Description = book.Description
        //});

        return mapper.Map<CommentGetDto>(comment);
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var comment = await context.Comments.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (comment == null)
            throw new ProcessException($"Comment (ID = {id}) not found.");

        context.Comments.Remove(comment);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CommentGetDto>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var comment = await context.Comments
            .Include(x => x.Author)
            .Include(x => x.Buyer)
            .ToListAsync();

        var result = mapper.Map<IEnumerable<CommentGetDto>>(comment);

        return result;
    }

    public async Task<CommentGetDto> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var comment = await context.Comments
            .Include(x => x.Author)
            .Include(x => x.Buyer)
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<CommentGetDto>(comment);

        return result;
    }
}
