using GenericController.Api.Models;

public class Customer : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

