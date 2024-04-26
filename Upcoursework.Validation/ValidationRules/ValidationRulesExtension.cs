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
    public static IRuleBuilderOptions<T, Guid> SkillExistance<T>(this IRuleBuilder<T, Guid> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Skill Id is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var skillExist = context.Skills.Any(s => s.Uid == id);
                return skillExist;
            }).WithMessage("Skill not found");
    }
    public static IRuleBuilderOptions<T, Guid> BuyerExistance<T>(this IRuleBuilder<T, Guid> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Buyer Id is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var buyerExist = context.Buyers.Any(s => s.Uid == id);
                return buyerExist;
            }).WithMessage("Buyer not found");
    }
    public static IRuleBuilderOptions<T, Guid?> AuthorExistance<T>(this IRuleBuilder<T, Guid?> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Author Id is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var authorExist = context.Authors.Any(s => s.Uid == id);
                return authorExist;
            }).WithMessage("Author not found");
    }

    //.Must(skills => skills.Distinct().Count() == skills.Count())
    //        .WithMessage("Duplicate skills are not allowed.")
    //public static IRuleBuilderOptions<T, ICollection<Guid>> SubjectsExistance<T>(this IRuleBuilder<T, ICollection<Guid>> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    //{
    //    return ruleBuilder
    //        .NotEmpty().WithMessage("At least one subject is required")
    //        .Must((ids) =>
    //        {
    //            using var context = contextFactory.CreateDbContext();
    //            var subjectsExist = ids.All(id => context.Subjects.Any(s => s.Uid == id));
    //            return subjectsExist;
    //        }).WithMessage("One or more subjects not found");
    //}
    public static IRuleBuilderOptions<T, Guid> SubjectExistance<T>(this IRuleBuilder<T, Guid> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("At least one subject is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var subjectExist = context.Subjects.Any(s => s.Uid == id);
                return subjectExist;
            }).WithMessage("Subject not found");
    }
    public static IRuleBuilderOptions<T, Guid?> SubjectExistance<T>(this IRuleBuilder<T, Guid?> ruleBuilder, IDbContextFactory<MainDbContext> contextFactory)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("At least one subject is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var subjectExist = context.Subjects.Any(s => s.Uid == id);
                return subjectExist;
            }).WithMessage("Subject not found");
    }

    public static IRuleBuilderOptions<T, string> OrderTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Order title is required")
            .MinimumLength(2).WithMessage("Minimum length is 1")
            .MaximumLength(200).WithMessage("Maximum length is 200");
    }
    public static IRuleBuilderOptions<T, decimal> OrderBudget<T>(this IRuleBuilder<T, decimal> ruleBuilder)
    {
        return ruleBuilder
            .GreaterThanOrEqualTo(0)
            .WithMessage("Budget cannot be negative");
    }
    public static IRuleBuilderOptions<T, string> OrderDescription<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty().WithMessage("Description is required")
            .MinimumLength(5).WithMessage("Minimum length is 5")
            .MaximumLength(10000).WithMessage("Maximum length is 10000");
    }

}
