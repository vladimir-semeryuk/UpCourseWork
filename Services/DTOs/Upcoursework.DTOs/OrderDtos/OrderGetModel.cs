using AutoMapper;
using Upcoursework.Common.Enums;
using Upcoursework.Context.Entities;
using Upcoursework.DTOs.AuthorDtos;
using Upcoursework.DTOs.CommentDtos;
using Upcoursework.DTOs.SkillDtos;
using Upcoursework.DTOs.SubjectDtos;

namespace Upcoursework.DTOs.OrderDtos;
public class OrderGetModel
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
    public SubjectGetDto Subject { get; set; }
    public required ICollection<SkillGetDto> SkillsRequired { get; set; }
    public virtual AuthorGetDto? Author { get; set; }
}

public class OrderGetDtoProfile : Profile
{
    public OrderGetDtoProfile()
    {
        CreateMap<Order, OrderGetModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
            .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
            .ForMember(dest => dest.CompletionStatus, opt => opt.MapFrom(src => src.CompletionStatus))
            .ForMember(dest => dest.Budget, opt => opt.MapFrom(src => src.Budget))
            .ForMember(dest => dest.IsBudgetNegotiable, opt => opt.MapFrom(src => src.IsBudgetNegotiable))
            .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
            .ForMember(dest => dest.SkillsRequired, opt => opt.MapFrom(src => src.SkillsRequired))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author));
    }
}
