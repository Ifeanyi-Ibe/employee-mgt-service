using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenGlobal.EmployeeService.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name}  ({key}) was not found.")
        {
        }
    }
}