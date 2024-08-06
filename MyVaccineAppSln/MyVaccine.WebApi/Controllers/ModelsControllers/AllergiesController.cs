using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyService _service;

        public AllergiesController(IAllergyService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
                return NotFound();

            var allergyDto = new AllergyDto
            {
                AllergyId = result.AllergyId,
                Name = result.Name,
                UserId = result.UserId
            };

            return Ok(allergyDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            var allergyDtos = result.Select(allergy => new AllergyDto
            {
                AllergyId = allergy.AllergyId,
                Name = allergy.Name,
                UserId = allergy.UserId
            });

            return Ok(allergyDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AllergyDto allergyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allergy = new Allergy
            {
                Name = allergyDto.Name,
                UserId = allergyDto.UserId
            };

            var createdAllergy = await _service.Add(allergy);

            var createdAllergyDto = new AllergyDto
            {
                AllergyId = createdAllergy.AllergyId,
                Name = createdAllergy.Name,
                UserId = createdAllergy.UserId
            };

            return CreatedAtAction(nameof(GetById), new { id = createdAllergyDto.AllergyId }, createdAllergyDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AllergyDto allergyDto)
        {
            if (id != allergyDto.AllergyId)
                return BadRequest("ID mismatch.");

            var existingAllergy = await _service.GetById(id);
            if (existingAllergy == null)
                return NotFound();

            existingAllergy.Name = allergyDto.Name;
            existingAllergy.UserId = allergyDto.UserId;

            await _service.Update(existingAllergy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
