
// Services/Implementations/AllergyService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly MyVaccineAppDbContext _context;

        public AllergyService(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<Allergy> GetById(int id)
        {
            return await _context.Allergies.FindAsync(id);
        }

        public async Task<IEnumerable<Allergy>> GetAll()
        {
            return await _context.Allergies.ToListAsync();
        }

        public async Task<Allergy> Add(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();
            return allergy;
        }

        public async Task Update(Allergy allergy)
        {
            _context.Allergies.Update(allergy);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var allergy = await _context.Allergies.FindAsync(id);
            if (allergy != null)
            {
                _context.Allergies.Remove(allergy);
                await _context.SaveChangesAsync();
            }
        }
    }
}

