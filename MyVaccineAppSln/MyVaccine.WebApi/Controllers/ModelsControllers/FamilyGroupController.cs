using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Models_Dtos.FamilyGroup;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers

{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyGroupController : ControllerBase
    {
        private readonly IFamilyGroupService _familyGroupService;

        public FamilyGroupController(IFamilyGroupService familyGroupService)
        {
            _familyGroupService = familyGroupService;
        }

        // GET: Obtiene todos los grupos familiares
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var familyGroups = await _familyGroupService.GetAll();
            return Ok(familyGroups);
        }

        // GET: Obtiene un grupo familiar por su ID
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var familyGroup = await _familyGroupService.GetById(id);
            if (familyGroup == null)
            {
                return NotFound();
            }
            return Ok(familyGroup);
        }

        // POST: Crea un nuevo grupo familiar
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FamilyGroupRequestDto familyGroupDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdFamilyGroup = await _familyGroupService.Add(familyGroupDto);
            return CreatedAtAction(nameof(GetById), new { id = createdFamilyGroup.FamilyGroupId }, createdFamilyGroup);
        }

        // PUT: Actualiza un grupo familiar existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FamilyGroupRequestDto familyGroupDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingFamilyGroup = await _familyGroupService.GetById(id);
            if (existingFamilyGroup == null)
            {
                return NotFound();
            }

            await _familyGroupService.Update(familyGroupDto, id);
            return NoContent();
        }


        // DELETE: Elimina un grupo familiar por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingFamilyGroup = await _familyGroupService.GetById(id);
            if (existingFamilyGroup == null)
            {
                return NotFound();
            }

            await _familyGroupService.Delete(id);
            return NoContent();
        }

        // POST: Añade un usuario a un grupo familiar
        [HttpPost("{familyGroupId}/users/{userId}")]
        public async Task<IActionResult> AddUserToFamilyGroup(int familyGroupId, int userId)
        {
            var familyGroup = await _familyGroupService.AddUserToFamilyGroup(familyGroupId, userId);
            if (familyGroup == null)
            {
                return NotFound();
            }
            return Ok(familyGroup);
        }
    }
}


