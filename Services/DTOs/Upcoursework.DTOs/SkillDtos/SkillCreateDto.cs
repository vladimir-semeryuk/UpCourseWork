using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Upcoursework.Validation;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.DTOs.SkillDtos;
public class SkillCreateDto
{
    public required string Title { get; set; }
}

public class SkillCreateDtoProfile : Profile
{
    public SkillCreateDtoProfile()
    {
        CreateMap<Skill, SkillCreateDto>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}

public class SkillCreateDtoValidator : AbstractValidator<SkillCreateDto>
{
    public SkillCreateDtoValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title).SkillTitle();
        RuleFor(x => x.Title)
            .MustAsync(async (title, cancellationToken) =>
            {
                using var context = contextFactory.CreateDbContext();
                return !await context.Subjects.AnyAsync(s => s.Title.ToLower() == title.ToLower());
            })
            .WithMessage("A skill with the same title already exists");
    }
}
