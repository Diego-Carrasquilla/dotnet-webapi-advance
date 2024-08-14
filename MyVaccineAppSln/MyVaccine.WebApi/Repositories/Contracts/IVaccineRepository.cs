using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IVaccineRepository
    {
        Task<Vaccine> GetById(int id);
        Task<IEnumerable<Vaccine>> GetAll();
        Task Add(Vaccine vaccine);
        Task Update(Vaccine vaccine);
        Task Delete(int id);
    }
}
