using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;
using Upcoursework.DTOs.AuthorDtos;
using Upcoursework.DTOs.FeedbackDtos;
using Upcoursework.DTOs.OrderDtos;

namespace Upcoursework.DTOs.CommentDtos;
public class CommentGetDto
{
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public required Guid UserId { get; set; }
    public required string UserDisplayName { get; set; }
}

public class CommentGetDtoProfile : Profile
{
    public CommentGetDtoProfile()
    {
        CreateMap<Comment, CommentGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Buyer.Uid))
            .ForMember(dest => dest.UserDisplayName, opt => opt.MapFrom(src => src.Buyer.DisplayName));
    }
}
