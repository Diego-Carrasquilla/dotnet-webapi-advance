using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IVaccineService
    {
        Task<VaccineResponseDto> GetById(int id);
        Task<IEnumerable<VaccineResponseDto>> GetAll();
        Task<VaccineResponseDto> Add(VaccineRequestDto request);
        Task<VaccineResponseDto> Update(VaccineRequestDto request, int id);
        Task Delete(int id);
    }
}
