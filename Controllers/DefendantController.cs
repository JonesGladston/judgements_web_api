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
        private judgement_dbContext _context;
        public DefendantController(judgement_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<DefendantData> GetDefendants(string search = "", string sort = "", int pageNumber = 1, int pageSize = 10)
        {
            var defendantDbSet = _context.Defendants;
            IQueryable<Defendants> totalDefendants = defendantDbSet.OrderBy(Defendant => Defendant.Id);
            string _search = search.ToLower();
            if (search != "")
            {
                totalDefendants = defendantDbSet.Where(a => a.CaseId.ToString().ToLower().Contains(_search) || a.FirstName.ToLower().Contains(_search) || a.LastName.ToLower().Contains(_search) || a.Attorney.ToLower().Contains(_search))
                    .OrderBy(a => a.Id);
            }

            if (sort != "")
                totalDefendants = new SortDefendants().Sort(sort, totalDefendants);

            var resultData = new DefendantData
            {
                TotalCount = defendantDbSet.Count(),
                defendants = totalDefendants.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };
            return resultData;
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
