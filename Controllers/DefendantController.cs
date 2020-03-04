using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("/defendants_100")]
        public ActionResult<List<Defendants>> GetLimited()
        {
            return _context.Defendants.Where(x => x.Id < 100).ToList();
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

        [HttpPost]
        public ActionResult<Defendants> Create(Defendants newDefendant)
        {
            _context.Defendants.Add(newDefendant);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Defendants> EditDefendant(long id, Defendants editDefendant)
        {
            var editableDefendant = _context.Defendants.Find(id);
            _context.Defendants.Update(editableDefendant).CurrentValues.SetValues(editDefendant);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Defendants>> DeleteDefendant(long id)
        {
            var deletableDefendant = await _context.Defendants.FindAsync(id);
            if (deletableDefendant == null)
            {
                return NotFound();
            }

            _context.Defendants.Remove(deletableDefendant);
            await _context.SaveChangesAsync();

            return deletableDefendant;
        }
    }

}
