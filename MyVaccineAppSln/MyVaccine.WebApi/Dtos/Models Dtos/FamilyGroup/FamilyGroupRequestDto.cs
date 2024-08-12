namespace MyVaccine.WebApi.Dtos.Models_Dtos.FamilyGroup
{
    public class FamilyGroupRequestDto
    {
        public string Name { get; set; }
        public List<int> UserIds { get; set; } // IDs of users to add in the group
    }
}
