using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Upcoursework.Validation;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.DTOs.SkillDtos;
using Upcoursework.DTOs.SubjectDtos;


namespace Upcoursework.DTOs.AuthorDtos;
public class AuthorCreateDto
{
    public required string DisplayName { get; set; }
    public required string Description { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
    public ICollection<Guid>? SubjectIds { get; set; }
    public ICollection<Guid>? SkillIds { get; set; }
    public ICollection<string>? NewSubjects { get; set; }
    public ICollection<string>? NewSkills { get; set; }
}

public class AuthorCreateDtoProfile : Profile
{
    public AuthorCreateDtoProfile()
    {
        CreateMap<AuthorCreateDto, Author>()
            .ForMember(dest => dest.Subjects, opt => opt.Ignore())
            .ForMember(dest => dest.Skills, opt => opt.Ignore())
            .ForMember(dest => dest.Orders, opt => opt.Ignore())
            .ForMember(dest => dest.Comments, opt => opt.Ignore())
            .AfterMap<AuthorCreateDtoActions>();
    }

    public class AuthorCreateDtoActions : IMappingAction<AuthorCreateDto, Author>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public AuthorCreateDtoActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(AuthorCreateDto source, Author destination, ResolutionContext context)
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
            destination.Orders = new List<Order>();
            destination.Comments = new List<Comment>();
        }
    }
}

public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
{
    public AuthorCreateDtoValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.DisplayName).DisplayName();

        RuleForEach(dto => dto.SkillIds)
            .SkillExistance(contextFactory)
            .When(dto => dto.SkillIds != null); // Only apply this rule when SkillIds are provided

        RuleFor(dto => dto.NewSkills)
            .NotEmpty()
            .WithMessage("At least one skill is required")
            .When(dto => dto.SkillIds == null); // Only apply this rule when SkillIds are null and NewSkills are not provided

        RuleForEach(dto => dto.NewSkills)
            .SkillTitle()
            .UniqueSkillTitle(contextFactory)
            .When(dto => dto.NewSkills != null);

        RuleForEach(dto => dto.SubjectIds)
            .SubjectExistance(contextFactory)
            .When(dto => dto.SubjectIds!= null); // Only apply this rule when SubjectIds are provided

        RuleFor(dto => dto.NewSubjects)
            .NotEmpty()
            .WithMessage("At least one subject is required")
            .When(dto => dto.SubjectIds == null);
        
        RuleForEach(dto => dto.NewSubjects)
            .SubjectTitle()
            .UniqueSubjectTitle(contextFactory)
            .When(dto => dto.NewSubjects != null);

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");

        RuleFor(x => x.Country)
            .NotEmpty();
    }
}
