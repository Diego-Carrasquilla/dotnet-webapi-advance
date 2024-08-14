using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineCategory;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IVaccineCategoryService
    {
        Task<VaccineCategoryResponseDto> GetById(int id);
        Task<IEnumerable<VaccineCategoryResponseDto>> GetAll();
        Task<VaccineCategoryResponseDto> Add(VaccineCategoryRequestDto request);
        Task<VaccineCategoryResponseDto> Update(VaccineCategoryRequestDto request, int id);
        Task Delete(int id);
    }
}
