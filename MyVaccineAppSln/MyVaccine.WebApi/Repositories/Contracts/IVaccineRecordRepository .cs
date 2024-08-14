using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IVaccineRecordRepository : IBaseRepository<VaccineRecord>
    {
        Task<VaccineRecord> GetByIdWithDetails(int id);
    }
}

