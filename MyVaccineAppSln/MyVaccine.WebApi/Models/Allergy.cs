using System.ComponentModel.DataAnnotations;

namespace MyVaccine.WebApi.Models
{
    public class Allergy : BaseTable
    {
        [Key]
        public int AllergyId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
