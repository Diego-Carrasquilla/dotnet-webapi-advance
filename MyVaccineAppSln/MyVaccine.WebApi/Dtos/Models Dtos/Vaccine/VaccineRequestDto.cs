namespace MyVaccine.WebApi.Dtos.Vaccine
{
    public class VaccineRequestDto
    {
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; }
        public bool RequireBooster { get; set; }
    }
}
