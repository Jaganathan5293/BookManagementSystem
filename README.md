# Book Management System

A full-stack application for managing books using ASP.NET Core API and Blazor WebAssembly.

## Project Structure

The solution consists of two main projects:

1. **BookManagementSystemAPI**: Backend API project
   - Controllers: Handle HTTP requests
   - Services: Business logic layer
   - Repositories: Data access layer
   - Models: Domain entities
   - Data: Database context and configurations

2. **BookManagementSystemWeb**: Frontend Blazor WebAssembly project
   - Pages: Blazor components for different views
   - Services: HTTP clients for API communication
   - Shared: Reusable components and models

## Prerequisites

- .NET 7.0 SDK
- Visual Studio 2022 or VS Code

## Getting Started

1. Clone the repository
2. Navigate to the solution directory
3. Run the backend API:
   ```bash
   cd BookManagementSystemAPI
   dotnet run
   ```
4. Run the Blazor WebAssembly frontend:
   ```bash
   cd BookManagementSystemWeb
   dotnet run
   ```

## Features

- View all books with options to edit, rate, or delete
- Add new books with validation
- Edit existing books
- Delete books with confirmation
- Calculate final price based on discount percentage

## API Endpoints

- GET /api/books - Get all books
- GET /api/books/{id} - Get a specific book
- POST /api/books - Create a new book
- PUT /api/books/{id} - Update an existing book
- DELETE /api/books/{id} - Delete a book
