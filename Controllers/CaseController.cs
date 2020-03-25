using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApiApp.Models;
using Newtonsoft.Json;

namespace webApiApp.Controllers
{
    [Route("Cases")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private judgement_dbContext _context;
        public CaseController(judgement_dbContext context)
        {
            _context = context;
            if (_context.cases.Count() == 0)
            {
                _context.cases.Add(new Cases { CourtType = "new_type" }); _context.SaveChanges();
            }
        }


        [HttpGet]
        public ActionResult<CaseData> GetCases(string search = "", string sort = "", int pageNumber = 1, int pageSize = 10)
        {
            var caseDbSet = _context.cases;
            IQueryable<Cases> totalCases = caseDbSet.OrderBy(Case => Case.Id);
            string _search = search.ToLower();
            if (search != "")
            {
                totalCases = caseDbSet.Where(a => a.CaseNo.ToLower().Contains(_search) || a.CaseType.ToLower().Contains(_search) || a.FillingDate.ToString().Contains(_search) || a.Judge.ToLower().Contains(_search))
                    .OrderBy(Case => Case.Id);
            }

            if (sort != "")
                totalCases = new SortCases().Sort(sort, totalCases);

            var resultData = new CaseData
            {
                TotalCount = caseDbSet.Count(),
                Cases = totalCases.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };
            return resultData;
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

        [HttpPost]
        public ActionResult<Cases> Create(Cases newCase)
        {
            _context.cases.Add(newCase);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cases>> EditCase(long id, Cases editCase)
        {
            var editableCase = await _context.cases.FindAsync(id);
            _context.cases.Update(editableCase).CurrentValues.SetValues(editCase);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cases>> DeleteCase(long id)
        {
            var deletableCase = await _context.cases.FindAsync(id);
            if (deletableCase == null)
            {
                return NotFound();
            }

            _context.cases.Remove(deletableCase);
            await _context.SaveChangesAsync();

            return deletableCase;
        }
    }

}
    