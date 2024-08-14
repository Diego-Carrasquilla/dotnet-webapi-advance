// Repositories/Interfaces/IAllergyRepository.cs
using MyVaccine.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVaccine.WebApi.Repositories.Interfaces
{
    public interface IAllergyRepository
    {
        Task<Allergy> GetById(int id);
        Task<IEnumerable<Allergy>> GetAll();
        Task Add(Allergy allergy);
        Task Update(Allergy allergy);
        Task Delete(int id);
    }
}
