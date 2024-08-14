using MyVaccine.WebApi.Dtos.Vaccine;

namespace MyVaccine.WebApi.Dtos.Models_Dtos.VaccineCategory
{
    public class VaccineCategoryResponseDto
    {
        public int VaccineCategoryId { get; set; }
        public string Name { get; set; }
        public List<VaccineRequestDto> Vaccines { get; set; }
    }
}
