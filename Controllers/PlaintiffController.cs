using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        [HttpGet]
        public ActionResult<PlaintiffData> GetPlaintiffs(string search = "", string sort = "", int pageNumber = 1, int pageSize = 10)
        {
            var caseDbSet = _context.Plaintiffs;
            IQueryable<Plaintiffs> totalPlaintiffs = caseDbSet.OrderBy(Plaintiff => Plaintiff.Id);
            string _search = search.ToLower();
            if (search != "")
            {
                totalPlaintiffs = caseDbSet.Where(a => a.CaseId.ToString().ToLower().Contains(_search) || a.FirstName.ToLower().Contains(_search) || a.LastName.ToLower().Contains(_search) || a.Attorney.ToLower().Contains(_search))
                    .OrderBy(Case => Case.Id);
            }

            if (sort != "")
                totalPlaintiffs = new SortPlaintiffs().Sort(sort, totalPlaintiffs);

            var resultData = new PlaintiffData
            {
                TotalCount = caseDbSet.Count(),
                plaintiffs = totalPlaintiffs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };
            return resultData;
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

        [HttpPost]
        public ActionResult<Plaintiffs> Create(Plaintiffs newPlaintiff)
        {
            _context.Plaintiffs.Add(newPlaintiff);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Cases> EditCase(long id, Plaintiffs editPlaintiff)
        {
            var editablePlaintiff = _context.Plaintiffs.Find(id);
            _context.Plaintiffs.Update(editablePlaintiff).CurrentValues.SetValues(editPlaintiff);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Plaintiffs>> DeletePlaintiff(long id)
        {
            var deletablePlaintiff = await _context.Plaintiffs.FindAsync(id);
            if (deletablePlaintiff == null)
            {
                return NotFound();
            }

            _context.Plaintiffs.Remove(deletablePlaintiff);
            await _context.SaveChangesAsync();

            return deletablePlaintiff;
        }
    }

}
