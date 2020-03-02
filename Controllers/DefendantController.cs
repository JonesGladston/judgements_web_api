using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApiApp.Models;
namespace webApiApp.Controllers
{
    [Route("Defendants")]
    [ApiController]
    public class DefendantController : ControllerBase
    {
        private readonly judgement_dbContext _context;
        public DefendantController(judgement_dbContext context)
        {
            _context = context;
            if (_context.Defendants.Count() == 0)
            {
                _context.Defendants.Add(new Defendants { FirstName = "tester" }); _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Defendants>> GetAll()
        {
            return _context.Defendants.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Defendants> GetById(long id)
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
