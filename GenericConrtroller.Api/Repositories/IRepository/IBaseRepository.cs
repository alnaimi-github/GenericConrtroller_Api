using GenericController.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericController.Api.Repositories.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
