# <div>Blog Management ASP.NET Core 6 CQRS & MediatR</div>

This is a sample ASP.NET Core 6 project that demonstrates how to use the CQRS (Command Query Responsibility Segregation) pattern with MediatR library for building a blog management system. The project includes basic CRUD operations for managing blog posts and comments, and uses an in-memory database for storing data.

<br/>

# <div>Technologies</div>
* <a href="https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0">ASP.NET Core 6</a>
* <a href="https://martinfowler.com/bliki/CQRS.html" target="_blank">CQRS pattern</a>
* <a href="https://fluentvalidation.net/">FluentValidation</a>
* <a href="https://automapper.org" target="_blank">AutoMapper</a>
* <a href="https://www.nuget.org/packages/MediatR" target="_blank">MediatR</a>

<br />

# <div>Installation and Usage</div>
<div>
  <p>To use this project, you'll need to have <a href="https://dotnet.microsoft.com/download/dotnet/6.0" target="_new">.NET 6 SDK</a> installed on your machine. Once you've installed .NET 6, you can clone this repository and run the project using the following command:</p>

<pre>
  <code class="!whitespace-pre hljs">dotnet run</code>
</pre>
  
  
  ## Overview

### Core

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### API
This layer Contains the API endpoints and controllers.
</div>

<br/>
