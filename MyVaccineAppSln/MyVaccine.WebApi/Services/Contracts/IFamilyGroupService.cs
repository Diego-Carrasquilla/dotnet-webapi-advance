using MyVaccine.WebApi.Dtos.Models_Dtos.FamilyGroup;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IFamilyGroupService
    {
        Task<FamilyGroupResponseDto> GetById(int id);
        Task<IEnumerable<FamilyGroupResponseDto>> GetAll();
        Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request);
        Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id);
        Task Delete(int id);
        Task<FamilyGroupResponseDto> AddUserToFamilyGroup(int familyGroupId, int userId);

    }
}
