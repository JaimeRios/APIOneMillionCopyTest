using APIOneMillionCopyTest.Application.DTOs;
using APIOneMillionCopyTest.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace APIOneMillionCopyTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class leadsController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public leadsController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LeadQueryParams query)
        {
            var result = await _leadService.GetAsync(query);
            return Ok(result);

        }

        [HttpGet(":id")]
        public async Task<IActionResult> GetById(int id)
        {
            var lead = await _leadService.GetByIdAsync(id);
            if (lead == null)
                return NotFound();
            return Ok(lead);
        }

        [HttpPatch(":id")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLeadDto dto)
        {  
            var isUpdate = await _leadService.UpdateAsync(id, dto);
            
            if(!isUpdate)
                return NotFound();

            return NoContent();
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDelete = await _leadService.DeleteAsync(id);
            if(!isDelete)
                return NotFound();

            return NoContent();
        }

    }
}
