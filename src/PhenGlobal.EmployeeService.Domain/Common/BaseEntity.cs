using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenGlobal.EmployeeService.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; } = default!;
        public string CreatedBy { get; set; } = default!;
    }
}