using AutoMapper;
using Upcoursework.Common.Enums;
using Upcoursework.Context.Entities;
using Upcoursework.DTOs.SkillDtos;
using Upcoursework.DTOs.SubjectDtos;

namespace Upcoursework.DTOs.OrderDtos;
public class OrderGetDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public byte[]? FileAttachment { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime? CompletedDate { get; set; }
    public OrderCompletionStatus CompletionStatus { get; set; }
    public decimal Budget { get; set; }
    public bool IsBudgetNegotiable { get; set; }
    public required SubjectGetDto Subject { get; set; }
    public required ICollection<SkillGetDto> Skills { get; set; }
    public Guid? AuthorId { get; set; }
    public string? AuthorName { get; set; }
}

public class OrderGetDtoProfile : Profile
{
    public OrderGetDtoProfile()
    {
        CreateMap<Order, OrderGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
            .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
            .ForMember(dest => dest.CompletionStatus, opt => opt.MapFrom(src => src.CompletionStatus))
            .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
            .ForMember(dest => dest.IsBudgetNegotiable, opt => opt.MapFrom(src => src.IsBudgetNegotiable))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.SkillsRequired))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom<AuthorGuidResolver>())
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom<AuthorNameResolver>());
    }
}

internal class AuthorGuidResolver : IValueResolver<Order, OrderGetDto, Guid?>
{
    public Guid? Resolve(Order source, OrderGetDto destination, Guid? member, ResolutionContext context)
    {
        return source.Author == null ? null : source.Author.Uid;
    }
}
internal class AuthorNameResolver : IValueResolver<Order, OrderGetDto, string?>
{
    public string? Resolve(Order source, OrderGetDto destination, string? member, ResolutionContext context)
    {
        return source.Author == null ? null : source.Author.DisplayName;
    }
}


