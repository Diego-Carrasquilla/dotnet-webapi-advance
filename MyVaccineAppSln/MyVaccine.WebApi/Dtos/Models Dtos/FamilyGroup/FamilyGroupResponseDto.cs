namespace MyVaccine.WebApi.Dtos.Models_Dtos.FamilyGroup
{
    public class FamilyGroupResponseDto
    {
        public int FamilyGroupId { get; set; }
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }  // List of User details in the FamilyGroup
    }
}
