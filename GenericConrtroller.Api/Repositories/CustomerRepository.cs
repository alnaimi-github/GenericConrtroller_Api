using GenericController.Api.Models;
using GenericController.Api.Repositories.IRepository;
using GenericController.Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GenericController.Api.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext db) : base(db) { }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _entities.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
