using APIOneMillionCopyTest.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIOneMillionCopyTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class leadsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public leadsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leads = await _context.Leads.ToListAsync();
            return Ok(leads);
        }


    }
}
