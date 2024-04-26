using AutoMapper;
using Upcoursework.Common.Enums;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.Context.Entities;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Upcoursework.Validation;

namespace Upcoursework.DTOs.OrderDtos;
public class OrderCreateDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public byte[]? FileAttachment { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime? CompletedDate { get; set; }
    public OrderCompletionStatus CompletionStatus { get; set; }
    public required virtual Guid Buyer { get; set; }
    public decimal Budget { get; set; }
    public bool IsBudgetNegotiable { get; set; }
    public Guid? Subject { get; set; }
    public string? NewSubject { get; set; }
    public ICollection<Guid>? SkillsRequired { get; set; }
    public ICollection<string>? NewSkills { get; set; }
    public virtual Guid? Author { get; set; }
}

public class OrderCreateDtoProfile : Profile
{
    public OrderCreateDtoProfile()
    {
        CreateMap<OrderCreateDto, Order>()
            .ForMember(dest => dest.Subject, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
            .ForMember(dest => dest.SkillsRequired, opt => opt.Ignore())
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.Buyer, opt => opt.Ignore())
            .AfterMap<OrderCreateDtoActions>();
    }

    public class OrderCreateDtoActions : IMappingAction<OrderCreateDto, Order>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public OrderCreateDtoActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(OrderCreateDto source, Order destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var skills = new List<Skill>();
            // Find and assign skills by their GUIDs
            if (source.SkillsRequired != null)
            {
                var existingSkills = db.Skills.Where(x => source.SkillsRequired.Contains(x.Uid)).ToList();
                skills.AddRange(existingSkills);
            }

            // Find and assign subjects by their GUIDs
            if (source.Subject != null)
            {
                var existingSubject = db.Subjects.FirstOrDefault(x => source.Subject == x.Uid);
                destination.Subject = existingSubject;
            }

            if (source.NewSkills != null)
            {
                List<Skill> newSkills = new List<Skill>();
                foreach (var skill in source.NewSkills)
                {
                    var newSkill = new Skill { Title = skill };
                    db.Skills.Add(newSkill);
                    skills.Add(newSkill);
                }
            }

            // Create new subjects for any provided new tags
            if (source.NewSubject != null && source.Subject == null)
            {
                var newSubject = new Subject() { Title = source.NewSubject };
                db.Subjects.Add(newSubject);
                destination.Subject = newSubject;
            }

            if (source.Author != null)
            {
                var existingAuthor = db.Authors.FirstOrDefault(x => source.Author == x.Uid);
                destination.Author = existingAuthor;
                destination.AuthorId = existingAuthor?.Id;
            }

            var existingBuyer = db.Buyers.FirstOrDefault(x => source.Buyer == x.Uid);
            destination.Buyer = existingBuyer;
            destination.BuyerId = existingBuyer.Id;
            destination.SkillsRequired = skills;
            destination.CreationDate = DateTime.UtcNow;
        }
    }
}
public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
{
    public OrderCreateDtoValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title).OrderTitle();

        RuleFor(x => x.Buyer)
            .BuyerExistance(contextFactory);

        RuleFor(x => x.Author)
            .AuthorExistance(contextFactory)
            .When(x => x.Author != null);

        RuleForEach(dto => dto.SkillsRequired)
            .SkillExistance(contextFactory)
            .When(dto => dto.SkillsRequired != null); // Only apply this rule when SkillIds are provided

        RuleFor(dto => dto.NewSkills)
            .NotEmpty()
            .WithMessage("At least one skill is required")
            .When(dto => dto.SkillsRequired == null); // Only apply this rule when SkillIds are null and NewSkills are not provided

        RuleForEach(dto => dto.NewSkills)
            .SkillTitle()
            .UniqueSkillTitle(contextFactory)
            .When(dto => dto.NewSkills != null);

        RuleFor(dto => dto.Subject)
            .SubjectExistance(contextFactory)
            .When(dto => dto.Subject != null); // Only apply this rule when SubjectIds are provided

        RuleFor(dto => dto.NewSubject)
            .NotEmpty()
            .WithMessage("At least one subject is required")
            .When(dto => dto.Subject == null);

        RuleFor(dto => dto.NewSubject)
            .SubjectTitle()
            .UniqueSubjectTitle(contextFactory)
            .When(dto => dto.NewSubject != null);

        RuleFor(x => x.Description).OrderDescription();

        RuleFor(x => x.Budget).OrderBudget();

        RuleFor(x => x.Deadline)
            .Must(x => x > DateTime.UtcNow)
            .WithMessage("Deadline must be a date in the future");
        RuleFor(x => x)

            .Must(x => x.CompletedDate < x.Deadline)
            .WithMessage("Completed date cannot be later than deadline")
            .When(x => x.CompletedDate != null);

        RuleFor(x => x.CompletionStatus).NotNull().WithMessage("Completion status is required.");
    }
}

