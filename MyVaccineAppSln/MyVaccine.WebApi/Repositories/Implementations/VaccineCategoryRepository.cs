using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineCategoryRepository : IVaccineCategoryRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineCategoryRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<VaccineCategory> GetById(int id)
        {
            return await _context.VaccineCategories
                .Include(vc => vc.Vaccines) // Incluir la navegación a Vaccines si es necesario
                .FirstOrDefaultAsync(vc => vc.VaccineCategoryId == id);
        }

        public async Task<IEnumerable<VaccineCategory>> GetAll()
        {
            return await _context.VaccineCategories
                .Include(vc => vc.Vaccines) // Incluir la navegación a Vaccines si es necesario
                .ToListAsync();
        }

        public async Task Add(VaccineCategory vaccineCategory)
        {
            await _context.VaccineCategories.AddAsync(vaccineCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Update(VaccineCategory vaccineCategory)
        {
            _context.VaccineCategories.Update(vaccineCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var vaccineCategory = await _context.VaccineCategories.FindAsync(id);
            if (vaccineCategory != null)
            {
                _context.VaccineCategories.Remove(vaccineCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
