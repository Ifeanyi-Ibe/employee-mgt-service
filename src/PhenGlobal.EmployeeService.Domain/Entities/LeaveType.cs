using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhenGlobal.EmployeeService.Domain.Common;

namespace PhenGlobal.EmployeeService.Domain.Entities
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set;} = default!;
        public int DefaultDays { get; set; } = default!;
    }
}