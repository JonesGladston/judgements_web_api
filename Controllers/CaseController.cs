using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using webApiApp.Models;
namespace webApiApp.Controllers
{
    [Route("Cases")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly judgement_dbContext _context;
        public CaseController(judgement_dbContext context)
        {
            _context = context;
            if (_context.cases.Count() == 0)
            {
                _context.cases.Add(new Cases { CourtType = "new_type" }); _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Cases>> GetAll()
        {
            return _context.cases.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Cases> GetById(long id)
        {
            var item = _context.cases.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }

}
