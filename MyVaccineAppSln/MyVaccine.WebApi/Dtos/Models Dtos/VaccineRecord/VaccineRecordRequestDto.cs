namespace MyVaccine.WebApi.Dtos.Models_Dtos.VaccineRecordDto
{
    public class VaccineRecordRequestDto
    {
        public int UserId { get; set; }
        public int DependentId { get; set; }
        public int VaccineId { get; set; }
        public DateTime DateAdministered { get; set; }
        public string AdministeredLocation { get; set; }
        public string AdministeredBy { get; set; }
    }
}
