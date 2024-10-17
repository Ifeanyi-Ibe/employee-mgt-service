using Microsoft.EntityFrameworkCore;
using PhenGlobal.EmployeeService.Application.Contracts.Persistence;

namespace PhenGlobal.EmployeeService.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EmployeeDbContext _dbContext;

        public GenericRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       public async Task<T?> Get(Guid id)
       {
          return await _dbContext.Set<T>().FindAsync(id);
       }

       public async Task<IReadOnlyList<T>> GetAll()
       {
            return await _dbContext.Set<T>().ToListAsync();
       }

       public async Task<T> Add(T entity)
       {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
       }

       public async Task<T> Update(T entity)
       {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
       }

       public async Task Delete(T entity)
       {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
       }

       public async Task<bool> Exists(Guid id)
       {
            var entity = await Get(id);
            return entity is not null;
       }

    }
}