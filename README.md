# TournamentsApi 🏆

A professional ASP.NET Core Web API for managing sports tournaments, built with a focus on clean architecture and scalability.

## 🚀 Key Features
- **Complete CRUD:** Manage tournaments with Title, Description, MaxPlayers, and Date.
- **Async/Await:** Fully asynchronous data flow from controller to database for optimal performance.
- **Search Functionality:** Filter tournaments via query parameters.
- **Validation:** Robust input validation using DataAnnotations (e.g., preventing past dates).

## 🛠 Tech Stack
- **Framework:** .NET 9/10 (ASP.NET Core Web API)
- **Database:** SQL Server
- **ORM:** Entity Framework Core (Code-First)
- **Documentation:** Swagger / OpenAPI

## 📂 Architecture
The project follows a "Clean-ish" architecture pattern:
- **Controllers:** Thin controllers handling HTTP requests.
- **Services:** Business logic layer isolated from the API.
- **DTOs:** Data Transfer Objects to separate internal models from API responses.
- **Data:** DbContext and Migrations for database version control.

## 🏁 Getting Started
1. Clone the repository.
2. Update the connection string in `appsettings.json`.
3. Run `dotnet ef database update` to create the database.
4. Run `dotnet run` and visit `/swagger` to test the API.
