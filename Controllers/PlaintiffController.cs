using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApiApp.Models;
namespace webApiApp.Controllers
{
    [Route("Plaintiffs")]
    [ApiController]
    public class PlaintiffController : ControllerBase
    {
        private readonly judgement_dbContext _context;
        public PlaintiffController(judgement_dbContext context)
        {
            _context = context;
            if (_context.Plaintiffs.Count() == 0)
            {
                _context.Plaintiffs.Add(new Plaintiffs { FirstName = "tester" }); _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Plaintiffs>> GetAll()
        {
            return _context.Plaintiffs.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Plaintiffs> GetById(long id)
        {
            var item = _context.Plaintiffs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }

}
