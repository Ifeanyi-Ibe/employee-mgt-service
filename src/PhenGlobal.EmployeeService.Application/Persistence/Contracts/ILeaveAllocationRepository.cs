using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhenGlobal.EmployeeService.Domain.Entities;

namespace PhenGlobal.EmployeeService.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        
    }
}