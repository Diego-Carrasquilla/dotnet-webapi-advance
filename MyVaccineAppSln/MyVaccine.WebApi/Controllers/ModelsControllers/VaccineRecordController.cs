using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos;
using MyVaccine.WebApi.Dtos.Models_Dtos.VaccineRecordDto;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Contracts.MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineRecordController : ControllerBase
    {
        private readonly IVaccineRecordService _vaccineRecordService;

        public VaccineRecordController(IVaccineRecordService vaccineRecordService)
        {
            _vaccineRecordService = vaccineRecordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccineRecords = await _vaccineRecordService.GetAll();
            return Ok(vaccineRecords);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccineRecord = await _vaccineRecordService.GetById(id);
            if (vaccineRecord == null)
            {
                return NotFound();
            }
            return Ok(vaccineRecord);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VaccineRecordRequestDto vaccineRecordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdVaccineRecord = await _vaccineRecordService.Add(vaccineRecordDto);
            return CreatedAtAction(nameof(GetById), new { id = createdVaccineRecord.VaccineRecordId }, createdVaccineRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VaccineRecordRequestDto vaccineRecordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _vaccineRecordService.Update(vaccineRecordDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vaccineRecordService.Delete(id);
            return NoContent();
        }
    }
}

