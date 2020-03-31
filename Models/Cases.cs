using System;
using System.Collections.Generic;
using System.Linq;

namespace webApiApp.Models
{
    public partial class Cases
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public decimal? Amount { get; set; }
        public string CourtType { get; set; }
        public string CaseType { get; set; }
        public DateTime? FillingDate { get; set; }
        public string Judge { get; set; }
        public string DocketType { get; set; }
        public string Description { get; set; }
        public string CaseNo { get; set; }
        public string CaseUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CaseData
    {
        public long TotalCount { get; set; }

        public List<Cases> Cases { get; set; }
    }

    public class SortCases
    {

        public IQueryable<Cases> Sort(string sort, IQueryable<Cases> data)
        {
            IQueryable<Cases> totalCases = data;
            switch (sort)
            {
                case "CaseNo_asc":
                    totalCases = totalCases.OrderBy(Case => Case.CaseNo);
                    break;
                case "CaseNo_dsc":
                    totalCases = totalCases.OrderByDescending(Case => Case.CaseNo);
                    break;
                case "CaseType_asc":
                    totalCases = totalCases.OrderBy(Case => Case.CaseType);
                    break;
                case "CaseType_dsc":
                    totalCases = totalCases.OrderByDescending(Case => Case.CaseType);
                    break;
                case "FilingDate_asc":
                    totalCases = totalCases.OrderBy(Case => Case.FillingDate);
                    break;
                case "FilingDate_dsc":
                    totalCases = totalCases.OrderByDescending(Case => Case.FillingDate);
                    break;
                case "Judge_asc":
                    totalCases = totalCases.OrderBy(Case => Case.Judge);
                    break;
                case "Judge_dsc":
                    totalCases = totalCases.OrderByDescending(Case => Case.Judge);
                    break;
            }

            return totalCases;
        }
    }
}
