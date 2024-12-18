<h1>PLAN:</h1>


- [x] LibraryManagement.sln<br>
- [ ] ├── LibraryManagement.Application<br>
- [ ] │   ├── Interfaces<br>
- [ ] │   ├── Features<br>
- [ ] │   │   ├── Books<br>
- [ ] │   │   ├── Users<br>
- [ ] │   │   └── Roles<br>
- [ ] │   ├── Behaviors<br>
- [ ] │   └── Models<br>
- [ ] ├── LibraryManagement.Domain<br>
- [ ] │   ├── Entities<br>
- [ ] │   ├── Common<br>
- [ ] │   └── Enums<br>
- [ ] ├── LibraryManagement.Infrastructure<br>
- [ ] │   ├── Persistence<br>
- [ ] │   │   ├── ApplicationDbContext.cs<br>
- [ ] │   │   ├── Identity<br>
- [ ] │   │   └── Migrations<br>
- [ ] │   ├── Identity<br>
- [ ] │   ├── Repositories<br>
- [ ] │   ├── UnitOfWork<br>
- [ ] │   └── Services<br>
- [ ] ├── LibraryManagement.Web<br>
- [ ] │   ├── Pages<br>
- [ ] │   │   ├── Books<br>
- [ ] │   │   ├── Identity<br>
- [ ] │   │   └── Admin<br>
- [ ] │   ├── Middleware<br>
- [ ] │   ├── Services<br>
- [ ] │   └── wwwroot<br>
- [ ] ├── LibraryManagement.UnitTests<br>
- [ ] ├── LibraryManagement.IntegrationTests<br>

**1. LibraryManagement.Application **<br>
Users: Handles user operations (create, read, update, delete).<br>
Roles: Handles role operations (add, update, delete, assign to users).<br>
Behaviors: Implements cross-cutting concerns like validation, caching, and logging.<br>
Models: Data transfer objects for books, users, and roles.<br>

**2. LibraryManagement.Domain**<br>
Book: The Book entity defined with properties from the requirements:
```bash
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public string ISBN { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public int PageCount { get; set; }
    public string Language { get; set; }
    public string Summary { get; set; }
    public int AvailableCopies { get; set; }
}
```
User and Role entities: Extend IdentityUser and IdentityRole.
<br>
<br>

**3. LibraryManagement.Infrastructure**<br>
Repositories: Implements repository pattern for BookRepository, UserRepository, and RoleRepository.<br>
UnitOfWork: Manages transaction integrity across repositories.<br>

```bash
public interface IUnitOfWork
{
    IBookRepository Books { get; }
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    Task<int> SaveAsync();
}
```
Identity: Configures ASP.NET Core Identity, integrating ApplicationUser and ApplicationRole.

**4. LibraryManagement.Web**
This layer provides Razor Pages for the following:<br>

**Books Pages:**<br>
List all books.<br>
Display book details.<br>
Provide placeholders for adding, updating, and deleting books (future features).<br>
**Identity Pages:**<br>
Registration, login, and logout functionality.<br>
**Admin Pages:**<br>
Manage users (create, view, update, delete).<br>
Manage roles (create, view, update, delete).<br>
Assign roles to users.<br>


**5. LibraryManagement.UnitTests**<br>
**Unit tests for:**<br>
Book CRUD operations.<br>
User and role management.<br>
Identity services (e.g., authentication).<br>
**6. LibraryManagement.IntegrationTests**<br>
**Tests the integration of:**<br>

Database access using EF Core.<br>
Identity authentication and role-based access control.<br>

<hr>
<hr>
<hr>
<hr>

# LibraryManagement

## Project Description
LibraryManagement is a web-based library system built using Clean Architecture principles, EF Core, and ASP.NET Core Identity. It provides CRUD operations for managing books, users, and roles.

---

## Features
### Phase 1 (This Assignment)
- **Book Management**:
  - List all books.
  - View detailed information about a book.

### Phase 2 (Future Enhancements)
- **Book Management**:
  - Add, update, and delete books.
  - Search books by title, author, or ISBN.
- **User Management**:
  - Add, update, and delete users.
  - Role-based access control (admin pages).
- **Role Management**:
  - Add, update, and delete roles.
  - Assign roles to users.
- **Authentication**:
  - User registration and login functionality.

---

## Project Structure
### 1. LibraryManagement.Application
Contains application logic and DTOs.
### 2. LibraryManagement.Domain
Defines core entities like `Book`, `User`, and `Role`.
### 3. LibraryManagement.Infrastructure
Handles database access, repositories, and Identity configuration.
### 4. LibraryManagement.Web
The Razor Pages-based UI.
### 5. LibraryManagement.UnitTests
Tests for application logic and services.
### 6. LibraryManagement.IntegrationTests
Integration tests for database and API endpoints.

---

## Tools & Technologies
- **ASP.NET Core**: Web framework.
- **EF Core**: ORM for database access.
- **ASP.NET Core Identity**: User and role management.
- **MediatR**: Implements CQRS pattern.
- **FluentValidation**: Validation framework.
- **xUnit**: Testing framework.

---

## Setup & Run
1. Update the connection string in `appsettings.json`.
2. Run `dotnet ef database update` to apply migrations.
3. Start the application with `dotnet run`.
4. Access the app at `http://localhost:5000`.

---

## Future Plans
- Role-based API endpoints.
- Caching using Redis for frequently accessed data.
- Add CI/CD pipelines for deployment.

---

Feel free to modify or extend the system based on your needs!


<hr>
<hr>
<hr>
<hr>



<br>
<br>
<h1>GENERAL PLAN:</h1>
LibraryManagement.sln<br>
├── LibraryManagement.Application<br>
│   ├── Interfaces<br>
│   ├── Features<br>
│   │   ├── Books<br>
│   │   ├── Members<br>
│   ├── Behaviors<br>
│   └── Models<br>
├── LibraryManagement.Domain<br>
│   ├── Entities<br>
│   ├── Common<br>
│   └── Enums<br>
├── LibraryManagement.Infrastructure<br>
│   ├── Persistence<br>
│   │   ├── ApplicationDbContext.cs<br>
│   │   ├── Identity<br>
│   │   └── Migrations<br>
│   ├── Identity<br>
│   └── Services<br>
├── LibraryManagement.Web<br>
│   ├── Pages<br>
│   ├── Areas<br>
│   │   ├── Identity<br>
│   ├── Middleware<br>
│   ├── Services<br>
│   └── wwwroot<br>
├── LibraryManagement.UnitTests<br>
├── LibraryManagement.IntegrationTests<br>


<br>
<br>
<hr>


Projects:
1. **CleanArchitectureRazor.Application**
2. **CleanArchitectureRazor.Domain**
3. **CleanArchitectureRazor.Infrastructure**
4. **CleanArchitectureRazor.WebUI**

---

1. **CleanArchitectureRazor.Application**
   - **Purpose**: Contains the application logic, DTOs, service interfaces, and handlers. No dependencies on EF Core or ASP.NET Core.
   - **Folders**:
     - **Interfaces**: Service interfaces used by the application layer.
     - **DTOs**: Data Transfer Objects for transferring data.
     - **Services**: Business logic services.
     - **Features**:
       - Organized by entity or feature, e.g., `Products` or `Users`.
       - Each folder contains `Commands`, `Queries`, and their respective handlers.
     - **Common**: Shared components, e.g., validation or mapping.

2. **CleanArchitectureRazor.Domain**
   - **Purpose**: Holds the core domain models and logic. No dependencies on EF Core or ASP.NET Core.
   - **Folders**:
     - **Entities**: POCOs representing database entities (e.g., `Product`, `User`).
     - **Enums**: Enumerations for the domain (e.g., `UserRoles`).
     - **ValueObjects**: Immutable objects that define attributes or properties (e.g., `Address`).
     - **Events**: Domain events.
     - **Exceptions**: Custom exceptions for the domain layer.
     - **Interfaces**: Interfaces for repositories and domain services.

3. **CleanArchitectureRazor.Infrastructure**
   - **Purpose**: Implements application interfaces, integrates EF Core, Identity, and other infrastructure concerns.
   - **Folders**:
     - **Persistence**:
       - `ApplicationDbContext`: EF Core database context.
       - Configurations for each entity using Fluent API.
     - **Identity**:
       - Configuration for ASP.NET Core Identity.
       - Seed roles and users.
     - **Services**: Concrete implementations of application services (e.g., email or file storage).
     - **Repositories**: EF Core repository implementations for domain interfaces.

4. **CleanArchitectureRazor.WebUI**
   - **Purpose**: The presentation layer for Razor Pages and controllers.
   - **Folders**:
     - **Pages**:
       - Organized by feature (e.g., `Products`, `Account`).
       - Each folder contains `.cshtml` and `PageModel` classes.
     - **ViewModels**: Models used to pass data between the Razor Pages and the view.
     - **wwwroot**: Static assets (e.g., CSS, JS, images).
     - **Middleware**: Custom middleware.
     - **Helpers**: UI-related helper classes or methods.
     - **Configurations**: Setup for DI, services, and middleware in `Program.cs` or `Startup.cs`.

---

**Optional Enhancements**:
- **Unit Testing and Integration Testing**:
  - Add a `CleanArchitectureRazor.Tests` project.
  - Use libraries like xUnit or NUnit.
  - Organize folders by layer and feature (e.g., `Application/Features/Products`).

- **API Integration**:
  - Add a `CleanArchitectureRazor.Api` project if you need a Web API.

- **Logging and Monitoring**:
  - Integrate tools like Serilog, Application Insights, or Seq in `Infrastructure`.

- **Background Jobs**:
  - Use libraries like Hangfire or Quartz.NET in `Infrastructure`.

- **Localization**:
  - Include a `Resources` folder in `WebUI` for handling translations.

- **Docker**:
  - Add `Dockerfile` and `docker-compose.yml` for containerization.

- **CI/CD**:
  - Setup GitHub Actions or Azure Pipelines for automation.
