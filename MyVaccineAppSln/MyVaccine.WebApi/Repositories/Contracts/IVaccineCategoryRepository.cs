using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IVaccineCategoryRepository
    {
        Task<VaccineCategory> GetById(int id);
        Task<IEnumerable<VaccineCategory>> GetAll();
        Task Add(VaccineCategory vaccineCategory);
        Task Update(VaccineCategory vaccineCategory);
        Task Delete(int id);
    }
}
