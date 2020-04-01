using System;
using System.Collections.Generic;
using System.Linq;

namespace webApiApp.Models
{
    public partial class Plaintiffs
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Attorney { get; set; }
        public string Address { get; set; }
        public int? CaseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class PlaintiffData
    {
        public long TotalCount { get; set; }

        public List<Plaintiffs> plaintiffs { get; set; }
    }

    public class SortPlaintiffs
    {

        public IQueryable<Plaintiffs> Sort(string sort, IQueryable<Plaintiffs> data)
        {
            IQueryable<Plaintiffs> totalCases = data;
            switch (sort)
            {
                case "CaseId_asc":
                    totalCases = totalCases.OrderBy(Plaintiff => Plaintiff.CaseId);
                    break;
                case "CaseId_dsc":
                    totalCases = totalCases.OrderByDescending(Plaintiff => Plaintiff.CaseId);
                    break;
                case "FirstName_asc":
                    totalCases = totalCases.OrderBy(Plaintiff => Plaintiff.FirstName);
                    break;
                case "FirstName_dsc":
                    totalCases = totalCases.OrderByDescending(Plaintiff => Plaintiff.FirstName);
                    break;
                case "LastName_asc":
                    totalCases = totalCases.OrderBy(Plaintiff => Plaintiff.LastName);
                    break;
                case "LastName_dsc":
                    totalCases = totalCases.OrderByDescending(Plaintiff => Plaintiff.LastName);
                    break;
                case "Attorney_asc":
                    totalCases = totalCases.OrderBy(Plaintiff => Plaintiff.Attorney);
                    break;
                case "Attorney_dsc":
                    totalCases = totalCases.OrderByDescending(Plaintiff => Plaintiff.Attorney);
                    break;
            }

            return totalCases;
        }
    }
}
