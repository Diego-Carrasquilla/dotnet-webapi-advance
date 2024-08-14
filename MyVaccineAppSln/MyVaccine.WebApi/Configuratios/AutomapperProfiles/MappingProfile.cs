using AutoMapper;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.Models_Dtos.Allergies;
using MyVaccine.WebApi.Dtos.Models_Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineCategory;
using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineRecordDto;
using MyVaccine.WebApi.Dtos.Vaccine;
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

        // Mapping for Allergy
        CreateMap<Allergy, AllergyRequestDto>().ReverseMap();
        CreateMap<Allergy, AllergyResponseDto>()
            .ForMember(dest => dest.AllergyId, opt => opt.MapFrom(src => src.AllergyId))
            .ReverseMap();

        // Mapping for FamilyGroup
        CreateMap<FamilyGroup, FamilyGroupRequestDto>().ReverseMap();
        CreateMap<FamilyGroup, FamilyGroupResponseDto>()
            .ForMember(dest => dest.FamilyGroupId, opt => opt.MapFrom(src => src.FamilyGroupId))
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users)).ReverseMap();

        // Mapping for User
        CreateMap<User, UserDto>().ReverseMap();

        // Mapping for Vaccine
        CreateMap<VaccineRequestDto, Vaccine>()
            .ReverseMap();
        CreateMap<Vaccine, VaccineResponseDto>()
            .ReverseMap();

        // Mapping for VaccineRecord
        CreateMap<VaccineRecordRequestDto, VaccineRecord>()
            .ReverseMap();
        CreateMap<VaccineRecord, VaccineRecordResponseDto>()
            .ForMember(dest => dest.RequiresBooster, opt => opt.MapFrom(src => src.Vaccine.RequireBooster)).ReverseMap();

        // Mapping for VaccineCategory
        CreateMap<VaccineCategoryRequestDto, VaccineCategory>().ReverseMap();
        CreateMap<VaccineCategory, VaccineCategoryResponseDto>().ReverseMap();





    }
}