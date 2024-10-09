using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhenGlobal.EmployeeService.Application.DTOs.Common;

namespace PhenGlobal.EmployeeService.Application.DTOs
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set;} = default!;
        public int DefaultDays { get; set; } = default!;
    }
}