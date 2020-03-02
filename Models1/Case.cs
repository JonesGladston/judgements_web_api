using System;
namespace webApiApp.Models
{
    public class Case
    {
        public int id { get; set; }
        public string type { get; set; }
        public float amount { get; set; }
        public string court_type { get; set; }
        public string filling_date { get; set; }
        public string judge { get; set; }
        public string docket_type { get; set; }
        public string description { get; set; }
        public string case_no { get; set; }
        public string case_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
