namespace MyVaccine.WebApi.Dtos
{
    public class AllergyDto
    {
        public int AllergyId { get; set; } 
        public string Name { get; set; }
        public int UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
