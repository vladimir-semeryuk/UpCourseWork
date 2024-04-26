using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.Validation;

namespace Upcoursework.DTOs.AuthorDtos;
public class AuthorUpdateDto
{
    public required string DisplayName { get; set; }
    public required string Description { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
    public ICollection<Guid> SubjectIds { get; set; }
    public ICollection<Guid> SkillIds { get; set; }
    public ICollection<string>? NewSubjects { get; set; }
    public ICollection<string>? NewSkills { get; set; }
}

public class AuthorUpdateDtoProfile : Profile
{
    public AuthorUpdateDtoProfile()
    {
        CreateMap<AuthorUpdateDto, Author>()
            .ForMember(dest => dest.Subjects, opt => opt.Ignore())
            .ForMember(dest => dest.Skills, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .ForMember(dest => dest.Comments,  opt => opt.Ignore())
            .AfterMap<AuthorUpdateDtoActions>();
    }

    public class AuthorUpdateDtoActions : IMappingAction<AuthorUpdateDto, Author>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public AuthorUpdateDtoActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(AuthorUpdateDto source, Author destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var skills = new List<Skill>();
            var subjects = new List<Subject>();
            // Find and assign skills by their GUIDs
            if (source.SkillIds != null)
            {
                var existingSkills = db.Skills.Where(x => source.SkillIds.Contains(x.Uid)).ToList();
                skills.AddRange(existingSkills);
            }

            // Find and assign subjects by their GUIDs
            if (source.SubjectIds != null)
            {
                var existingSubjects = db.Subjects.Where(x => source.SubjectIds.Contains(x.Uid)).ToList();
                subjects.AddRange(existingSubjects);
            }

            if (source.NewSkills != null)
            {
                List<Skill> newSkills = new List<Skill>();
                foreach (var skill in source.NewSkills)
                {
                    var newSkill = new Skill { Title = skill };
                    if (db.Skills.Any(s => s.Title.ToLower() == newSkill.Title.ToLower()))
                    {
                        continue;
                    }
                    db.Skills.Add(newSkill);
                    skills.Add(newSkill);
                }
            }

            // Create new subjects for any provided new tags
            if (source.NewSubjects != null)
            {
                List<Subject> newSubjects = new List<Subject>();
                foreach (var subject in source.NewSubjects)
                {
                    var newSubject = new Subject { Title = subject };
                    db.Subjects.Add(newSubject);
                    subjects.Add(newSubject);
                }
            }

            destination.Subjects = subjects;
            destination.Skills = skills;
            //destination.Orders = new List<Order>();
            //destination.Comments = new List<Comment>();
        }
    }
}

public class AuthorUpdateDtoValidator : AbstractValidator<AuthorUpdateDto>
{
    public AuthorUpdateDtoValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.DisplayName).DisplayName();

        RuleForEach(x => x.SkillIds).SkillExistance(contextFactory);

        RuleForEach(x => x.SubjectIds).SubjectExistance(contextFactory);

        RuleFor(x => x.Description).AuthorDescription();

        RuleFor(x => x.Country).NotEmpty();
    }
}

