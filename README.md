# TournamentsApi 🏆
A professional ASP.NET Core Web API for managing sports tournaments, built with a focus on clean architecture, security, and scalability.

## 🚀 Key Features
Complete CRUD & Relations: Manage tournaments and their associated games with a full One-to-Many relationship.

Search Functionality: Filter tournaments efficiently via query parameters.

Partial Updates (PATCH): Support for updating specific fields like tournament titles without sending the full object.

JWT Security: Protected endpoints (like DELETE) using JWT Bearer Authentication.

Rate Limiting: Built-in protection on POST requests to prevent server spam.

Validation: Robust input validation using DataAnnotations and custom attributes like FutureDate.

Seed Data: The database is automatically populated with "GG Masters" and sample games upon creation.

## 🏁 Terminal Commands
To set up the project and the database, run the following commands in your terminal:

1. Update the database (creates tables and applies seed data):

Bash
<pre>
dotnet ef database update
</pre>
2. Launch the application:

Bash
<pre>
dotnet run
</pre>
3. (Optional) Create a new migration if you change the models:

Bash
<pre>
dotnet ef migrations add [MigrationName]
</pre>
## 📂 Architecture
The project follows a "Thin Controller" and Service Layer pattern to ensure high maintainability:

Controllers: Handle HTTP routing and return appropriate status codes.

Services: Encapsulate all business logic and database interactions.

DTOs: Separate internal database models from the public API interface.

Data: Manages the AppDbContext and configures entity relationships.

## 💡 Testing Instructions
When the app runs, Swagger opens automatically. To test the protected features:

Generate a Token: Use the /api/auth/login endpoint to get a JWT string.

Authorize: Click the Authorize button at the top right of the Swagger UI.

Input: Type Bearer  (with a space) followed by your token string.

Execute: You can now successfully call the DELETE endpoint.
