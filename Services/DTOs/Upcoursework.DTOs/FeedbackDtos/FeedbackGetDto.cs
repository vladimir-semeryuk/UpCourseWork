using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Common.Enums;
using Upcoursework.Context.Entities;
using Upcoursework.DTOs.AuthorDtos;

namespace Upcoursework.DTOs.FeedbackDtos;
public class FeedbackGetDto
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public FeedbackTypes Type { get; set; }
}

public class FeedbackGetDtoProfile : Profile
{
    public FeedbackGetDtoProfile()
    {
        CreateMap<Feedback, FeedbackGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.BuyerId, opt => opt.MapFrom(src => src.Buyer.Uid))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
    }
}