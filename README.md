<h1>LibraryManagement System</h1>

# Overview
A .NET 9 MVC application following the Clean Architecture approach for managing books, users, and roles in a library system. It includes user authentication, book management, and role-based access control.

<hr>
# Project Structure
<pre>
LibraryManagement/
│
├── LibraryManagement.Application/          # Application Layer - Contains business logic and service interfaces
│   ├── Common/                             # Shared components
│   │   ├── Interfaces/                     # Interface definitions for Repositories and Unit of Work
│   │   │   ├── IApplicationUserRepository.cs
│   │   │   ├── IBookRepository.cs
│   │   │   ├── IDbInitializer.cs
│   │   │   ├── IRepository.cs
│   │   │   └── IUnitOfWork.cs
│   │   └── Utility/                        # Utility classes (if any)
│   │
│   └── Services/                           # Service Layer
│       ├── Implementation/                 # Service implementations
│       │   └── BookService.cs              # Book service logic
│       └── Interface/                      # Service interfaces
│           └── IBookService.cs
│
├── LibraryManagement.Domain/               # Domain Layer - Contains core business models/entities
│   ├── Entities/                           # Domain entities
│   │   ├── ApplicationUser.cs              # User entity
│   │   └── Book.cs                         # Book entity
│
├── LibraryManagement.Infrastructure/       # Infrastructure Layer - Implements Repositories and Database Access
│   ├── Data/                               # Database context and initializers
│   │   ├── ApplicationDbContext.cs         # EF Core DbContext configuration
│   │   └── DbInitializer.cs                # Database seeding logic
│   │
│   ├── Migrations/                         # EF Core Migrations (auto-generated files)
│   │   └── ...                             # Migration files
│   │
│   └── Repository/                         # Repository implementations
│       ├── ApplicationUserRepository.cs    # Repository for managing ApplicationUser
│       ├── BookRepository.cs               # Repository for managing Book entity
│       ├── Repository.cs                   # Generic repository implementation
│       └── UnitOfWork.cs                   # Unit of Work pattern implementation
│
├── LibraryManagement.Web/                  # Presentation Layer - ASP.NET MVC Application
│   ├── Controllers/                        # MVC Controllers
│   │   ├── AccountController.cs            # Manages user authentication
│   │   ├── BookController.cs               # Manages book CRUD operations
│   │   ├── DashboardController.cs          # Manages dashboard page
│   │   ├── HomeController.cs               # Manages home page
│   │   ├── RoleController.cs               # Manages roles and permissions
│   │   └── UserController.cs               # Manages users
│   │
│   ├── Models/                             # View models for error handling or shared logic
│   │   └── ErrorViewModel.cs
│   │
│   ├── ViewModels/                         # Strongly typed objects for views
│   │   ├── HomeVM.cs                       # ViewModel for Home
│   │   ├── LoginVM.cs                      # ViewModel for Login
│   │   ├── RegisterVM.cs                   # ViewModel for Registration
│   │   └── RolesVM.cs                      # ViewModel for Roles
│   │
│   ├── Views/                              # Razor views organized by feature
│   │   ├── Account/                        # Views related to account management
│   │   │   ├── AccessDenied.cshtml
│   │   │   ├── Login.cshtml
│   │   │   └── Register.cshtml
│   │   │
│   │   ├── Book/                           # Views for managing books
│   │   │   ├── Create.cshtml
│   │   │   ├── Delete.cshtml
│   │   │   ├── Index.cshtml
│   │   │   └── Update.cshtml
│   │   │
│   │   ├── Dashboard/                      # Dashboard views
│   │   │   └── Index.cshtml
│   │   │
│   │   ├── Home/                           # Views for home page
│   │   │   ├── Index.cshtml
│   │   │   └── Privacy.cshtml
│   │   │
│   │   ├── Role/                           # Role management views
│   │   │   ├── Index.cshtml
│   │   │   └── Upsert.cshtml
│   │   │
│   │   ├── Shared/                         # Shared layouts and partial views
│   │   │   ├── _Layout.cshtml              # Main layout
│   │   │   ├── _LayoutAdmin.cshtml         # Admin-specific layout
│   │   │   ├── _LoginPartial.cshtml        # Login partial view
│   │   │   ├── _LoginPartialAdmin.cshtml   # Admin login partial view
│   │   │   ├── _Notification.cshtml        # Notification partial view
│   │   │   ├── _ValidationScriptsPartial.cshtml
│   │   │   └── Error.cshtml
│   │   │
│   │   └── User/                           # User-specific views
│   │       ├── Index.cshtml
│   │       ├── ManageRole.cshtml
│   │       ├── _ViewImports.cshtml
│   │       └── _ViewStart.cshtml
│   │
│   ├── wwwroot/                            # Static files (CSS, JS, images)
│   │   └── ...
│   │
│   ├── appsettings.json                    # Application configuration
│   ├── appsettings.Development.json        # Development-specific settings
│   └── Program.cs                          # Entry point of the application
│
└── Solution.sln                            # Solution file for Visual Studio

</pre>

<hr>
<br>

The solution consists of 4 projects:
## 1. LibraryManagement.Application
<ul>
    <li>Contains application-level logic and interfaces.</li>
    <li>Common/Interfaces: Repositories, Unit of Work, and DB Initializer interfaces.</li>
    <li>Services: Book-related services and their implementation.</li>
</ul>

## 2. LibraryManagement.Domain
<ul>
    <li>Contains domain entities.</li>
    <li>Entities: Core models like ApplicationUser and Book.</li>
</ul>

## 3. LibraryManagement.Infrastructure
<ul>
    <li>Implements database access and repositories.</li>
    <li>Data: ApplicationDbContext for EF Core configurations.</li>
    <li>Repository: Concrete implementations of repositories and Unit of Work.</li>
</ul>

## 4. LibraryManagement.Web
<ul>
    <li>The MVC application for user interaction.</li>
    <li>Controllers: Handle user requests for accounts, books, roles, etc.</li>
    <li>Models: Error handling view models.</li>
    <li>ViewModels: Data transfer objects for views.</li>
    <li>Views: Razor views organized by feature.</li>
    <ul>
        <li>Account: Login and Registration pages.</li>
        <li>Book: CRUD pages for managing books.</li>
        <li>Shared: Layout and partial views.</li>
    </ul>
    <li>wwwroot: Static files like CSS and JS.</li>
</ul>

# Features
<ul>
    <li>User Authentication: Secure login and registration.</li>
    <li>Book Management: Add, edit, delete, and view books.</li>
    <li>Role Management: Role-based access control (RBAC) for users.</li>
    <li>Error Handling: Includes a global and normal error-handling system.</li>
    <li>Clean Architecture: Separation of concerns between layers.</li>
</ul>

# Prerequisites
<ul>
    <li>.NET 9 SDK</li>
    <li>SQL Server or an equivalent database</li>
    <li>IDE: Visual Studio 2022</li>
</ul>

# Installation

1. Clone the repository:

```bash
git clone https://github.com/dotnet-tasks/LibraryManagement.git
cd LibraryManagement
```

2. Setup the database:
- Update appsettings.json with your database connection string.
- Run migrations:
- 
```bash
dotnet ef database update --project LibraryManagement.Infrastructure
```

4. Run the application:
```bash
dotnet run --project LibraryManagement.Web
```
4. Open the browser and visit https://localhost: ...



## Technologies Used
- .NET 9 (ASP.NET Core MVC)
- Entity Framework Core (for ORM and database access)
- Razor Views (Frontend templating engine)
- SQL Server (Database)

