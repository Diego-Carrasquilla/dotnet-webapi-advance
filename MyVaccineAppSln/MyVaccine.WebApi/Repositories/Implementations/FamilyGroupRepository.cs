using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class FamilyGroupRepository : IFamilyGroupRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public FamilyGroupRepository(MyVaccineAppDbContext context)
        {
            _context = context;
        }

        public async Task<FamilyGroup> GetById(int id)
        {
            return await _context.FamilyGroups.FindAsync(id);
        }

        public async Task<IEnumerable<FamilyGroup>> GetAll()
        {
            return await _context.FamilyGroups.ToListAsync();
        }

        public async Task Add(FamilyGroup familyGroup)
        {
            await _context.FamilyGroups.AddAsync(familyGroup);
            await _context.SaveChangesAsync();
        }

        public async Task Update(FamilyGroup familyGroup)
        {
            _context.FamilyGroups.Update(familyGroup);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var familyGroup = await GetById(id);
            if (familyGroup != null)
            {
                _context.FamilyGroups.Remove(familyGroup);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FamilyGroup> GetByIdWithUsers(int id)
        {
            return await _context.FamilyGroups
                .Include(fg => fg.Users)
                .FirstOrDefaultAsync(fg => fg.FamilyGroupId == id);
        }
    }
}

