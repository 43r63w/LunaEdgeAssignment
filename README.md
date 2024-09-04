# LunaEdgeAssignment
 This repository accommodates for the test task from LunaEdge


 # LunaTask.Api

## Overview

LunaTask.Api is a project that provides a RESTful API for task management. It includes CRUD operations for tasks and user authentication functionalities.

## Project Structure

The solution consists of the following projects:

- **LunaTask.Api**: The main API project.
- **LunaTask.BLL**: The business logic layer.
- **LunaTask.DAL**: The data access layer.
- **LunaTask.XUnitTest**: The unit tests for the solution.

## Prerequisites


Before you begin, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [PostgreSQL](https://www.postgresql.org/download/)

## Getting Started

### 1. Clone the repository

```sh
git clone https://github.com/your-repo/lunatask.api.git
cd lunatask.api
```
### 2. Set up the database
Ensure you have a SQL Server instance running, either locally or using Docker:

# If 
Migrations need to be written manually, they are automatically accepted when the application is launched.

```sh
docker run --name postgres_container -e POSTGRES_USER=myuser -e POSTGRES_PASSWORD=mypassword -e POSTGRES_DB=mydatabase -p 5432:5432 -d postgres:latest
```
Update the connection strings in `appsettings.json` in the LunaTask.Api project.

### 3. Run the API
You can now run the API:

```sh
dotnet run --project LunaTask.Api
```
The API will be available at `https://localhost:5001`

### 4.Docker Support
The solution includes Docker support with a docker-compose file. You can build and run the entire solution using Docker:

```sh
docker-compose up --build
```
This will set up the API and any other dependencies defined in the `docker-compose` file.

### 5.API Documentation
This project uses Swagger for API documentation. After running the project, you can view the API documentation at:

```sh
https://localhost:5001/swagger/index.html
```

  
