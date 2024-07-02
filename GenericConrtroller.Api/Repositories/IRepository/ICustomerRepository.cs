namespace GenericController.Api.Repositories.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer?> GetCustomerByEmailAsync(string email);
    }
}
