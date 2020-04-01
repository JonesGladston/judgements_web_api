using System;
using System.Collections.Generic;
using System.Linq;

namespace webApiApp.Models
{
    public partial class Defendants
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

    public class DefendantData
    {
        public long TotalCount { get; set; }

        public List<Defendants> defendants { get; set; }
    }

    public class SortDefendants
    {

        public IQueryable<Defendants> Sort(string sort, IQueryable<Defendants> data)
        {
            IQueryable<Defendants> totalCases = data;
            switch (sort)
            {
                case "CaseId_asc":
                    totalCases = totalCases.OrderBy(Defendant => Defendant.CaseId);
                    break;
                case "CaseId_dsc":
                    totalCases = totalCases.OrderByDescending(Defendant => Defendant.CaseId);
                    break;
                case "FirstName_asc":
                    totalCases = totalCases.OrderBy(Defendant => Defendant.FirstName);
                    break;
                case "FirstName_dsc":
                    totalCases = totalCases.OrderByDescending(Defendant => Defendant.FirstName);
                    break;
                case "LastName_asc":
                    totalCases = totalCases.OrderBy(Defendant => Defendant.LastName);
                    break;
                case "LastName_dsc":
                    totalCases = totalCases.OrderByDescending(Defendant => Defendant.LastName);
                    break;
                case "Attorney_asc":
                    totalCases = totalCases.OrderBy(Defendant => Defendant.Attorney);
                    break;
                case "Attorney_dsc":
                    totalCases = totalCases.OrderByDescending(Defendant => Defendant.Attorney);
                    break;
            }

            return totalCases;
        }
    }
}
