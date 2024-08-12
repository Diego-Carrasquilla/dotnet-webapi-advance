using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MyVaccine.WebApi.Repositories.Implementations
{
    public class VaccineRecordRepository : BaseRepository<VaccineRecord>, IVaccineRecordRepository
    {
        private readonly MyVaccineAppDbContext _context;

        public VaccineRecordRepository(MyVaccineAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VaccineRecord> GetByIdWithDetails(int id)
        {
            return await _context.VaccineRecords
                .Include(vr => vr.User)
                .Include(vr => vr.Dependent)
                .Include(vr => vr.Vaccine)
                .FirstOrDefaultAsync(vr => vr.VaccineRecordId == id);
        }
        public async Task Delete(int id)
        {
            var vaccineRecord = await _context.VaccineRecords.FindAsync(id);
            if (vaccineRecord != null)
            {
                _context.VaccineRecords.Remove(vaccineRecord);
                await _context.SaveChangesAsync();
            }



        }
    }
}


