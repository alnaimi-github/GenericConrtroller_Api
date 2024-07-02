using GenericController.Api.Models;

namespace GenericController.Api.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

}

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class Customer : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

