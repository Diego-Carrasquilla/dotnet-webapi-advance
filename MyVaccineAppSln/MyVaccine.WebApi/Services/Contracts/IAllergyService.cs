
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IAllergyService
    {
        Task<Allergy> GetById(int id);  // Tipo de retorno es Allergy
        Task<IEnumerable<Allergy>> GetAll();
        Task<Allergy> Add(Allergy allergy);  // El parámetro es Allergy
        Task Update(Allergy allergy);  // El parámetro es Allergy
        Task Delete(int id);
    }
}

