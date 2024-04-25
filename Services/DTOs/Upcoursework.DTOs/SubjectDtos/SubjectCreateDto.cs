using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Validation;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.DTOs.SubjectDtos;
public class SubjectCreateDto
{
    public required string Title { get; set; }
}

public class SubjectCreateDtoProfile : Profile
{
    public SubjectCreateDtoProfile()
    {
        CreateMap<Subject, SubjectCreateDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}

public class SubjectCreateDtoValidator : AbstractValidator<SubjectCreateDto>
{
    public SubjectCreateDtoValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title).SubjectTitle();
        RuleFor(x => x.Title)
            .MustAsync(async (title, cancellationToken) =>
            {
                using var context = contextFactory.CreateDbContext();
                return !await context.Subjects.AnyAsync(s => s.Title.ToLower() == title.ToLower());
            })
            .WithMessage("A subject with the same title already exists");
    }
}
