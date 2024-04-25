using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.DTOs.AuthorDtos;

namespace Upcoursework.DTOs.SubjectDtos;
public class SubjectGetDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    // public ICollection<AuthorGetDto> Authors { get; set; }
    // public ICollection<OrderGetDto> Orders { get; set; }
}

public class SubjectGetDtoProfile : Profile
{
    public SubjectGetDtoProfile()
    {
        CreateMap<Subject, SubjectGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}