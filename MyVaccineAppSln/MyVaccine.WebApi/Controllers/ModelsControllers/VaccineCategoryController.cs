using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineCategory;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineCategoryController : ControllerBase
    {
        private readonly IVaccineCategoryService _vaccineCategoryService;

        public VaccineCategoryController(IVaccineCategoryService vaccineCategoryService)
        {
            _vaccineCategoryService = vaccineCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccineCategories = await _vaccineCategoryService.GetAll();
            return Ok(vaccineCategories);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccineCategory = await _vaccineCategoryService.GetById(id);
            if (vaccineCategory == null)
            {
                return NotFound();
            }
            return Ok(vaccineCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VaccineCategoryRequestDto vaccineCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVaccineCategory = await _vaccineCategoryService.Add(vaccineCategoryDto);
            return CreatedAtAction(nameof(GetById), new { id = createdVaccineCategory.VaccineCategoryId }, createdVaccineCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VaccineCategoryRequestDto vaccineCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingVaccineCategory = await _vaccineCategoryService.GetById(id);
            if (existingVaccineCategory == null)
            {
                return NotFound();
            }

            await _vaccineCategoryService.Update(vaccineCategoryDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingVaccineCategory = await _vaccineCategoryService.GetById(id);
            if (existingVaccineCategory == null)
            {
                return NotFound();
            }

            await _vaccineCategoryService.Delete(id);
            return NoContent();
        }
    }
}
