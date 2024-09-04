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

```sh
docker run --name postgres_container -e POSTGRES_USER=myuser -e POSTGRES_PASSWORD=mypassword -e POSTGRES_DB=mydatabase -p 5432:5432 -d postgres:latest
```
Update the connection strings in `appsettings.json` in the LunaTask.Api project.

### 3. Apply Migrations
Navigate to the `LunaTask.DAL` project and apply migrations to the database:

```sh
dotnet ef database update --project LunaTask.DAL
```
  
