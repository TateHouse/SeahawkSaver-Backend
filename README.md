<div align="center">
<img src="https://cdn.freebiesupply.com/logos/thumbs/2x/uncw-logo.png" width="300" height="300">
</div>

# Seahawk Saver - Backend

## Overview

The backend for my CSC-450: Software Engineering project called `Seahawk Saver`, an application targeted towards
students to efficiently and easily manage their finances.

This backend API is built using `ASP.NET Core Minimal Web API` with a clean architecture inspired approach mixed with
feature folders. A strong emphasis is placed on SOLID principles and design patterns.

## Configuration

There are a number of configurations that can be changed in this application. Most of which can be found in the various
`AppSettings` `JSON` files.

You will need to provide the `JWT_SECRET_KEY` either as an environment variable or using `.NET User Secrets` for the API
to run and for all the tests to pass. Your JWT secret key should have a length of at least 256 and should be provided as
a string value for the previously mentioned key name. There are two projects this needs to be done for.

* `SeahawkSaverBackend.API`
* `SeahawkSaverBackend.Authentication.IntegrationTest`

## Endpoints

Swagger documentation is available at the `/swagger` endpoint.

## Future Plans

Even though I have finished the course this project was created for, there are a few things I would still like to do.
Some include adding additional information to each financial entity, adding a few new entities, and some general
cleaning up and refactoring around the codebase.

I would also like to go back through and complete are the automated tests. We decided to skip a lot of them due to time
constrains.

## Demos

* [User Demo](https://youtu.be/9imzY8K3QiY?si=4UsUuUQkJpYpEMHm)
* [Admin Demo](https://youtu.be/9hXEDy0F0ao?si=huqD1nMd4j8wtYCk)

## Dependencies

Dependencies are managed through `NuGet`. Some of the important packages in the solution include:

* Ardalis.Specification
* Ardalis.Specification.EntityFrameworkCore
* AutoMapper
* BCrypt.Net-Next
* FluentEmail.Core
* FluentEmail.Smtp
* FluentValidation
* FluentValidation.DependencyInjectionExtensions `
* MeditaR
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.AspNetCore.Mvc.Testing
* Microsoft.AspNetCore.OpenApi
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.InMemory
* Microsoft.Extensions.Configuration.Abstractions
* Microsoft.Extensions.Configuration.Binder
* Moq
* NUnit
* Swashbuckle.AspNetCore