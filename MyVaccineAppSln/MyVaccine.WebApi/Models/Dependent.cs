
using System.ComponentModel.DataAnnotations;

namespace MyVaccine.WebApi.Models;

public class Dependent : BaseTable
{
    [Key]
    public int DependId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<VaccineRecord> VaccineRecords { get; set; }

}
    

