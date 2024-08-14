using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IFamilyGroupRepository
    {
        Task<FamilyGroup> GetById(int id);
        Task<IEnumerable<FamilyGroup>> GetAll();
        Task Add(FamilyGroup familyGroup);
        Task Update(FamilyGroup familyGroup);
        Task Delete(int id);
        Task<FamilyGroup> GetByIdWithUsers(int id);  // Method to get a FamilyGroup with Users
    }
}
