# Product Management System

A secure ASP.NET Core MVC application that demonstrates Product Management functionality with Authentication and Authorization.

## Features

### Authentication & Authorization

* User Login and Logout
* JWT Token-Based Authentication
* Cookie-Based Authentication
* Role-Based Authorization
* Protected Routes and Secure Access Control
* Session Management

### Product Management (CRUD)

* Create New Products
* View Product List
* Edit Existing Products
* Delete Products
* Product Details View
* Form Validation

### Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* JWT Authentication
* Cookie Authentication
* LINQ
* Razor Views
* Bootstrap 5
* C#
* HTML, CSS, JavaScript
* jQuery
* AJAX

## Project Structure

* Controllers

  * Account Controller
  * Product Controller

* Models

  * Product
  * User

* DTOs

  * ProductDto
  * LoginDto

* Data

  * ApplicationDbContext

* Views

  * Login
  * Dashboard
  * Product Management Pages

## Authentication Flow

1. User enters login credentials.
2. Credentials are validated against the database.
3. JWT token is generated upon successful authentication.
4. Authentication cookie is created and stored.
5. Authorized users can access protected pages.
6. Unauthorized users are redirected to the login page.

## Product Operations

### Create Product

Allows authenticated users to add new products.

### View Products

Displays all available products in a responsive table.

### Update Product

Allows modification of existing product information.

### Delete Product

Removes products from the system after confirmation.

## Database

The application uses SQL Server with Entity Framework Core Code-First approach.

### Product Table

| Column      | Type     |
| ----------- | -------- |
| Id          | int      |
| ProductName | nvarchar |
| Description | nvarchar |
| Price       | decimal  |
| Colour      | nvarchar |

## Security Features

* JWT Token Validation
* Cookie Authentication
* Authorization Attributes
* Route Protection
* Input Validation
* Error Handling

## Getting Started

### Prerequisites

* .NET 8 SDK (or your project version)
* SQL Server
* Visual Studio 2022

### Installation

1. Clone the repository

```bash
git clone https://github.com/yourusername/your-repository.git
```

2. Update the database connection string in `appsettings.json`

3. Apply migrations

```bash
Update-Database
```

4. Run the application

```bash
dotnet run
```

## Learning Outcomes

This project demonstrates:

* ASP.NET Core MVC Architecture
* Entity Framework Core
* JWT Authentication
* Cookie Authentication
* Authorization and Security
* CRUD Operations
* Form Validation
* Repository and Service Layer Concepts
* SQL Server Integration

## Future Enhancements

* User Registration
* Role Management
* Refresh Tokens
* Product Search and Filtering
* Pagination
* API Integration
* Unit Testing

## Author

Sayani Deb

LinkedIn: https://www.linkedin.com/in/sayani-deb-21886722b/

GitHub: https://github.com/SayaniDeb10
