using System;

namespace HRSupportApi.Domain.Entities
{
    public class Intern
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public int Grade { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MentorId { get; set; }
        public string Notes { get; set; }
    }
}
