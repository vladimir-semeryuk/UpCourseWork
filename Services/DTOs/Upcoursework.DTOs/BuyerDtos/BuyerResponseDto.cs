using AutoMapper;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.DTOs.CommentDtos;
using Upcoursework.DTOs.FeedbackDtos;
using Upcoursework.DTOs.OrderDtos;

namespace Upcoursework.DTOs.BuyerDtos;
public class BuyerResponseDto
{
    public Guid Id { get; set; }
    public required string DisplayName { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
    public ICollection<Guid>? OrderIds { get; set; }
    public ICollection<string>? OrderTitles { get; set; }
    public ICollection<CommentGetDto>? Comments { get; set; }
    public ICollection<Guid>? FeedbackIds { get; set; }
}

public class BuyerResponseDtoProfile : Profile
{
    public BuyerResponseDtoProfile()
    {
        CreateMap<Buyer, BuyerResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.OrderIds, opt => opt.MapFrom(src => src.Orders.Select(o => o.Uid).ToList()))
            .ForMember(dest => dest.OrderTitles, opt => opt.MapFrom(src => src.Orders.Select(o => o.Title).ToList()))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.FeedbackIds, opt => opt.MapFrom(src => src.Feedback.Select(f => f.Uid).ToList()));
    }
}