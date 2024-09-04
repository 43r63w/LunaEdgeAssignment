


 # LunaTask.Api

## Overview

LunaTask.Api is a project that provides a RESTful API for task management. It includes CRUD operations for tasks and user authentication functionalities.

## Project Structure

The solution consists of the following projects:

The application is a monolith split into n-layer arichetecture

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
gh repo clone 43r63w/LunaEdgeAssignment
cd lunatask.api
```

### 2. Run the API
You can now run the API:

```sh
dotnet run --project LunaTask.Api
```
The API will be available at `https://localhost:5001`

### 3.Docker Support
The solution includes Docker support with a docker-compose file. You can build and run the entire solution using Docker:

```sh
docker-compose up --build
```
This will set up the API and any other dependencies defined in the `docker-compose` file.

after the command `docker-compose`
after the command you can open the api documentation by URL

```sh
http://localhost:1111/swagger/index.html
https://localhost:7777/swagger/index.html
```
### 4.API Documentation
In order to use the endpoints of the tasks
In order to use endpoints of tasks, you must first register and login 




### 5.API Documentation
This project uses Swagger for API documentation. After running the project, you can view the API documentation at:
![image](https://github.com/user-attachments/assets/a9a5eece-6e94-4769-9f85-9a2b52a5b545)

Then come in
![image](https://github.com/user-attachments/assets/677f9ffe-b01d-4fad-b99e-8835315d8078)
![image](https://github.com/user-attachments/assets/2a5697ec-c812-449c-8494-dd6ad7c00c98)
Then you can create tasks and edit




```sh
https://localhost:5001/swagger/index.html
```

![image](https://github.com/user-attachments/assets/6bc04a29-12b4-4966-ae6e-8d77f3e7c432)
- `SortColumn`: answers by which column to sort. In total, you can sort by
date
status
priority
by default, sorts by the title column

-  `PageNumber & PageSize`: needed for pagination

-  `SortBy`: You can sort in descending or ascending order






  
