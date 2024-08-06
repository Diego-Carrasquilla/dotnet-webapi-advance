
// Services/Implementations/AllergyService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly List<Allergy> _allergies = new List<Allergy>();

        public Task<Allergy> GetById(int id)
        {
            var allergy = _allergies.FirstOrDefault(a => a.AllergyId == id);
            return Task.FromResult(allergy);
        }

        public Task<IEnumerable<Allergy>> GetAll()
        {
            return Task.FromResult<IEnumerable<Allergy>>(_allergies);
        }

        public Task<Allergy> Add(Allergy allergy)
        {
            allergy.AllergyId = _allergies.Count + 1; // Simulación de ID autoincremental
            _allergies.Add(allergy);
            return Task.FromResult(allergy);
        }

        public Task Update(Allergy allergy)
        {
            var existingAllergy = _allergies.FirstOrDefault(a => a.AllergyId == allergy.AllergyId);
            if (existingAllergy != null)
            {
                existingAllergy.Name = allergy.Name;
                existingAllergy.UserId = allergy.UserId;
                // Actualiza otras propiedades si es necesario
            }
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var allergy = _allergies.FirstOrDefault(a => a.AllergyId == id);
            if (allergy != null)
            {
                _allergies.Remove(allergy);
            }
            return Task.CompletedTask;
        }
    }
}

