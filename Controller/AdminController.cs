using Microsoft.AspNetCore.Mvc;
using muzey.Data;
using muzey.Models;

namespace muzey.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("addnewysl", Name = "addnewysl")]
        public async Task<IActionResult> AddNewYsl(Yslygi data)
        {
            _context.Yslygi.Add(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
