using Microsoft.AspNetCore.Mvc;
using muzey.Data;
using muzey.Models;

namespace muzey.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogControllers : ControllerBase
    {
        private ApplicationDbContext _context;
        public CatalogControllers(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Yslygi> Get()
        {
            return _context.Yslygi.ToList();
        }
    }
}
