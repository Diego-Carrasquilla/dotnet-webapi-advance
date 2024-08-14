using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;

        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccines = await _vaccineService.GetAll();
            return Ok(vaccines);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccine = await _vaccineService.GetById(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VaccineRequestDto vaccineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVaccine = await _vaccineService.Add(vaccineDto);
            return CreatedAtAction(nameof(GetById), new { id = createdVaccine.VaccineId }, createdVaccine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VaccineRequestDto vaccineDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingVaccine = await _vaccineService.GetById(id);
            if (existingVaccine == null)
            {
                return NotFound();
            }

            await _vaccineService.Update(vaccineDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingVaccine = await _vaccineService.GetById(id);
            if (existingVaccine == null)
            {
                return NotFound();
            }

            await _vaccineService.Delete(id);
            return NoContent();
        }
    }
}
