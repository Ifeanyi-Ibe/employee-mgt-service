using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhenGlobal.EmployeeService.Domain.Common;

namespace PhenGlobal.EmployeeService.Domain.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType LeaveType { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public string RequestComments { get; set; } = default!;
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}