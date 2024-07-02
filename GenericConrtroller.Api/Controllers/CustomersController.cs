using GenericController.Api.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericController.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseController<Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
