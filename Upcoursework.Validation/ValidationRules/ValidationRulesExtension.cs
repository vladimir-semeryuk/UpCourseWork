using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.Validation;
public static class ValidationRuleExtensions
{
    public static IRuleBuilderOptions<T, string> DisplayName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Display name is required")
            .MinimumLength(2).WithMessage("Minimum length is 2")
            .MaximumLength(100).WithMessage("Maximum length is 100");
    }

    public static IRuleBuilderOptions<T, string> AuthorDescription<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .WithMessage("Description is required")
            .MinimumLength(3)
            .MaximumLength(1000)
            .WithMessage("Maximum length is 1000");
    }
    public static IRuleBuilderOptions<T, string> SubjectTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Subject title is required")
            .MinimumLength(2).WithMessage("Minimum length is 1")
            .MaximumLength(100).WithMessage("Maximum length is 200");
    }
    public static IRuleBuilderOptions<T, string> UniqueSubjectTitle<T>(this IRuleBuilder<T, string> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .Must(title =>
            {
                using var context = contextFactory.CreateDbContext();
                return !context.Subjects.Any(s => s.Title.ToLower() == title.ToLower());
            })
            .WithMessage("A subject with the same title already exists");
    }
    public static IRuleBuilderOptions<T, string> SkillTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Skill title is required")
            .MinimumLength(2).WithMessage("Minimum length is 1")
            .MaximumLength(100).WithMessage("Maximum length is 100");
    }
    public static IRuleBuilderOptions<T, string> UniqueSkillTitle<T>(this IRuleBuilder<T, string> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .Must(title =>
            {
                using var context = contextFactory.CreateDbContext();
                return !context.Skills.Any(s => s.Title.ToLower() == title.ToLower());
            })
            .WithMessage("A skill with the same title already exists");
    }
    public static IRuleBuilderOptions<T, ICollection<Guid>> SkillsExistance<T>(this IRuleBuilder<T, ICollection<Guid>> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("At least one skill is required")
            .Must((ids) =>
            {
                using var context = contextFactory.CreateDbContext();
                var skillsExist = ids.All(id => context.Skills.Any(s => s.Uid == id));
                return skillsExist;
            }).WithMessage("One or more skills not found");
    }

    //.Must(skills => skills.Distinct().Count() == skills.Count())
    //        .WithMessage("Duplicate skills are not allowed.")
    public static IRuleBuilderOptions<T, ICollection<Guid>> SubjectsExistance<T>(this IRuleBuilder<T, ICollection<Guid>> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("At least one subject is required")
            .Must((ids) =>
            {
                using var context = contextFactory.CreateDbContext();
                var subjectsExist = ids.All(id => context.Subjects.Any(s => s.Uid == id));
                return subjectsExist;
            }).WithMessage("One or more subjects not found");
    }

}
