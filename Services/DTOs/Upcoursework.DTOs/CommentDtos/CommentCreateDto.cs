using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;

namespace Upcoursework.DTOs.CommentDtos;
public class CommentCreateDto
{
    public required string Text { get; set; }
    public required Guid UserId { get; set; }
    public required string UserDisplayName { get; set; }
}

public class CommentCreateDtoProfile : Profile
{
    public CommentCreateDtoProfile()
    {
        CreateMap<Comment, CommentGetDto>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Buyer.Uid))
            .ForMember(dest => dest.UserDisplayName, opt => opt.MapFrom(src => src.Buyer.DisplayName));
    }
}