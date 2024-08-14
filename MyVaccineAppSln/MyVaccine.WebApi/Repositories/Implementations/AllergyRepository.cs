// Repositories/Implementations/AllergyRepository.cs
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class AllergyRepository : IAllergyRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public AllergyRepository(MyVaccineAppDbContext context)
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

        public async Task Add(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            await _context.SaveChangesAsync();
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
