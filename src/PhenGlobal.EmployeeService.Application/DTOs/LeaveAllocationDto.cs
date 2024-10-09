using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhenGlobal.EmployeeService.Application.DTOs.Common;

namespace PhenGlobal.EmployeeService.Application.DTOs
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; } = default!;
        public int Period { get; set; } = default!;
        public LeaveTypeDto LeaveType { get; set; } = default!;
        public Guid LeaveTypeId { get; set; }
    }
}