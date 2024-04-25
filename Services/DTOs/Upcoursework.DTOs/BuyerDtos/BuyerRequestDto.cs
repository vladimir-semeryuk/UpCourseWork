using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Upcoursework.Context.Context;
using Upcoursework.Context.Entities;
using Upcoursework.Validation;

namespace Upcoursework.DTOs.BuyerDtos;
public class BuyerRequestDto
{
    public required string DisplayName { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public required string Country { get; set; }
}

public class BuyerRequestDtoProfile : Profile
{
    public BuyerRequestDtoProfile()
    {
        CreateMap<BuyerRequestDto, Buyer>()
            .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
    }
}

public class BuyerRequestDtoValidator : AbstractValidator<BuyerRequestDto>
{
    public BuyerRequestDtoValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.DisplayName).DisplayName();

        RuleFor(x => x.Country)
            .NotEmpty();
    }
}
