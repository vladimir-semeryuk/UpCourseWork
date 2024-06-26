﻿using AutoMapper;
using Upcoursework.Context.Entities;


namespace Upcoursework.DTOs.CommentDtos;
public class CommentGetDto
{
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public required Guid UserId { get; set; }
    public required string UserDisplayName { get; set; }
    public required Guid AuthorId { get; set; }
}

public class CommentGetDtoProfile : Profile
{
    public CommentGetDtoProfile()
    {
        CreateMap<Comment, CommentGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Buyer.Uid))
            .ForMember(dest => dest.UserDisplayName, opt => opt.MapFrom(src => src.Buyer.DisplayName))
            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.Uid));
    }
}
