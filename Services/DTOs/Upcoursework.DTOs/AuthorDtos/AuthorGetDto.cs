using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Common.Enums;
using Upcoursework.Context.Entities;
using Upcoursework.DTOs.CommentDtos;
using Upcoursework.DTOs.FeedbackDtos;
using Upcoursework.DTOs.OrderDtos;
using Upcoursework.DTOs.SkillDtos;
using Upcoursework.DTOs.SubjectDtos;

namespace Upcoursework.DTOs.AuthorDtos;
public class AuthorGetDto
{
    public Guid Id { get; set; }
    public required string DisplayName { get; set; }
    public required string Description { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
    public ICollection<SubjectGetDto> Subjects { get; set; }
    public ICollection<SkillGetDto> Skills { get; set; }
    public ICollection<OrderGetDto> Orders { get; set; }
    public ICollection<CommentGetDto> Comments { get; set; }
    public ICollection<FeedbackGetDto> Feedback { get; set; }
}

public class AuthorGetDtoProfile : Profile
{
    public AuthorGetDtoProfile()
    {
        CreateMap<Author, AuthorGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects))
            .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills))
            .ForMember(dest => dest.Feedback, opt => opt.MapFrom(src => src.Feedback))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders));
    }
}
