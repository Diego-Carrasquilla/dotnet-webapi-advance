using AutoMapper;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping for Dependent
        CreateMap<Dependent, DependentRequestDto>().ReverseMap();
        CreateMap<Dependent, DependentResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DependId)).ReverseMap();

        //Mapping For Allergy
        CreateMap<Allergy, AllergyDto>().ReverseMap();

    }
}