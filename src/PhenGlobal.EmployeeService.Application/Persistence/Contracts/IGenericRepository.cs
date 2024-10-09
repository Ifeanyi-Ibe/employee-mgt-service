using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhenGlobal.EmployeeService.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}