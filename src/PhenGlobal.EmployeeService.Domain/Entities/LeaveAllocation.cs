using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhenGlobal.EmployeeService.Domain.Common;

namespace PhenGlobal.EmployeeService.Domain.Entities
{
    public class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; } = default!;
        public int Period { get; set; } = default!;
        public LeaveType LeaveType { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }
    }
}