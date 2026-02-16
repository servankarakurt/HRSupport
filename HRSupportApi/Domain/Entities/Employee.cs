using HRSupportApi.Domain.Enums;
using System;

namespace HRSupportApi.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public EmployeeType Type { get; set; }
        public string PasswordHash { get; set; }
    }
}
