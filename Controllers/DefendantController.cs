using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApiApp.Models;
namespace webApiApp.Controllers
{
    [Route("Defendant")]
    [ApiController]
    public class DefendantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DefendantController(ApplicationDbContext context)
        {
            _context = context;
            if (_context.Defendants.Count() == 0)
            {
                _context.Defendants.Add(new Case { court_type = "new_type" }); _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Case>> GetAll()
        {
            return _context.Defendants.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Case> GetById(int id)
        {
            var item = _context.Defendants.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }

}
