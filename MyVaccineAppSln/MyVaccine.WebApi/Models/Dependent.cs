
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyVaccine.WebApi.Models
{
    public class Dependent
    {
        [Key]//saltaba un error porque no tenia una "primary key" definida, asi lo solucione
        public int DependId { get; set; }
        public required string Name { get; set; }
        public DateTime DateOfBirt { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public List<VaccineRecord> VaccineRecords { get; set; }
    }
}
