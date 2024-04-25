using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.DTOs.SkillDtos;
public class SkillGetDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    //public virtual ICollection<Author> Authors { get; set; }
    //public virtual ICollection<Order> Orders { get; set; }
}

public class SkillGetDtoProfile : Profile
{
    public SkillGetDtoProfile()
    {
        CreateMap<Skill, SkillGetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Uid))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}
