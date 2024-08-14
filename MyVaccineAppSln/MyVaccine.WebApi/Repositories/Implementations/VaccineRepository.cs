using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<Vaccine> GetById(int id)
        {
            return await _context.Vaccines.FindAsync(id);
        }

        public async Task<IEnumerable<Vaccine>> GetAll()
        {
            return await _context.Vaccines.ToListAsync();
        }

        public async Task Add(Vaccine vaccine)
        {
            await _context.Vaccines.AddAsync(vaccine);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Vaccine vaccine)
        {
            _context.Vaccines.Update(vaccine);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var vaccine = await _context.Vaccines.FindAsync(id);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
                await _context.SaveChangesAsync();
            }
        }
    }
}
