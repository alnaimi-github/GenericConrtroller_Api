🌟 GenericController.Api 🌟



Overview 🚀
GenericController.Api is an extensible ASP.NET Core Web API designed to streamline the implementation of CRUD operations for various entities. This project leverages a generic repository pattern and base controller, minimizing boilerplate code and enhancing code reuse. It's ideal for developers seeking a robust and maintainable architecture for managing different types of data models.

Features ✨
🛠 Generic Repository Pattern: Centralizes common CRUD operations to reduce redundancy and improve maintainability.
📦 Base Controller: A generic controller to handle standard API actions (GET, POST, PUT, DELETE) for any entity type.
🔗 Dependency Injection: Utilizes ASP.NET Core's built-in DI to manage repository instances seamlessly.
⚡ Asynchronous Operations: Supports async methods for better performance and scalability.
💾 Entity Framework Core Integration: Uses EF Core for data access, with support for SQL Server.
📈 Logging and Configuration: Preconfigured logging and connection string management for easy setup.
Getting Started 💡
Prerequisites 📋
.NET 6 SDK
SQL Server
Installation 🛠
Clone the repository:

sh
Copy code
git clone https://github.com/yourusername/GenericController.Api.git
cd GenericController.Api
Update the connection string:

Modify the appsettings.json file to match your SQL Server instance and database:

json
Copy code
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ConnectionStringDb": "Server=YourServerName;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;TrustServerCertificate=True;"
  }
}
Restore NuGet packages and build the project:

sh
Copy code
dotnet restore
dotnet build
Apply migrations and update the database:

sh
Copy code
dotnet ef database update
Run the application:

sh
Copy code
dotnet run
Usage 📚
Once the application is running, you can interact with the API using tools like Postman or curl.

Example Endpoints 🔗
GET /api/product - Retrieve all products
GET /api/product/{id} - Retrieve a product by ID
POST /api/product - Add a new product
PUT /api/product/{id} - Update an existing product
DELETE /api/product/{id} - Delete a product by ID
Project Structure 📁
plaintext
Copy code
GenericController.Api/
├── Controllers/
│   ├── BaseController.cs
│   ├── ProductController.cs
│   ├── CustomerController.cs
├── Data/
│   ├── AppDbContext.cs
├── Models/
│   ├── BaseEntity.cs
│   ├── Product.cs
│   ├── Customer.cs
├── Repositories/
│   ├── BaseRepository.cs
│   ├── ProductRepository.cs
│   ├── CustomerRepository.cs
│   └── IRepository/
│       ├── IBaseRepository.cs
│       ├── IProductRepository.cs
│       ├── ICustomerRepository.cs
├── Program.cs
├── appsettings.json
├── Startup.cs
Dependency Injection Setup 🛠
To ensure proper DI setup, make sure to register your repositories in Program.cs:

csharp
Copy code
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IBaseRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Add DbContext with configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringDb")));

// Add other services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
Contributing 🤝
Contributions are welcome! Please fork this repository and submit a pull request for review.

Steps to Contribute:
Fork the repository.
Create a new branch (git checkout -b feature/YourFeature).
Commit your changes (git commit -am 'Add some feature').
Push to the branch (git push origin feature/YourFeature).
Create a new Pull Request.
License 📄
This project is licensed under the MIT License. See the LICENSE file for details.

Enjoy coding! 🎉
