# Bookstore Project

This project was made to (or at least, attempt to) put in practice everything that I learn from my main tech stack: .NET and React.

## Backend - .NET (C#)

The project is a web rest api with two entities, Book and Category, containing all CRUD operations for both, following the diagram:

![project's class diagram](https://github.com/RafaelLammel/Bookstore/blob/master/bookstore.png?raw=true)

Made in .NET 6, using the following:

- **Entity Framework**, for data access (SQLite)
- **AutoMapper**, to easily map entities to DTOs and vice versa
- **Swagger**, for Endpoint documentation
- **FluentValidation**, to make Entity validation easier

Apart from technologies, I also tried to apply the following concepts, as I understand them:

- **SOLID** principles
- **Clean Architecture**, using project layers as explained in this article: https://docs.microsoft.com/pt-br/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures
- **Repository Pattern**
- **Migrations** (Entity Framework)

### Run the Project:
---

To run this project, make sure you have .NET 6 SDK in your machine.

In your terminal, do the following:
Install the global EF CLI:

```sh
dotnet tool install --global dotnet-ef
```

Inside the "Bookstore.API" folder, containing the "Bookstore.API.csproj", run this command to create the SQLite DB from the migrations:

```sh
dotnet ef database update
```

After the DB is created, run:

```sh
dotnet run
```

The project should start on https://localhost:7169 and http://localhost:5169.
Swagger will run at https://localhost:7169/swagger/index.html

## Frontend (React)
---
## WIP