using HRSupportApi.Domain.Enums;
using System;

namespace HRSupportApi.Domain.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public LeaveStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string RejectionReason { get; set; }
    }
}
