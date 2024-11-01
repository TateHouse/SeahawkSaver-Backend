<div align="center">
<img src="https://cdn.freebiesupply.com/logos/thumbs/2x/uncw-logo.png" width="300" height="300">
</div>

# Seahawk Saver - Backend

## Overview

The backend for my CSC-450: Software Engineering group project called `Seahawk Saver`, an application targeted towards
students to efficiently and easily manage their finances.

This backend API is built using `ASP.NET Core Minimal Web API` with a clean architecture approach and feature folders. A
strong emphasis is placed on SOLID principles and design patterns.

## Configuration

There are a number of configurations that can be changed in this application. Most of which can be found in the various
`AppSettings` `JSON` files.

You will need to provide the `JWT_SECRET_KEY` either as an environment variable or using `.NET User Secrets` for the API
to run and for all the tests to pass. Your JWT secret key should have a length of at least 256 and should be provided as
a string value for the previously mentioned key name.

## Building and Deployment

Instructions for building and deployment will be provided in the future. This backend will eventually be containerized
using `Docker` and the entire application will utilize `Docker Compose` to deploy all the necessary components
(frontend, backend, database, SMTP server, ...) in one easy-to-use package.

## Dependencies

Dependencies are managed through `NuGet`. The explicitly installed packages in the solution include:

- Ardalis.Specification `8.0.0`
- Ardalis.Specification.EntityFrameworkCore `8.0.0`
- AutoMapper `13.0.1`
- BCrypt.Net-Next `4.0.3`
- coverlet.collector `6.0.0`
- FluentEmail.Core `3.0.2`
- FluentEmail.Smtp `3.0.2`
- FluentValidation `11.10.0`
- FluentValidation.DependencyInjectionExtensions `11.10.0`
- MeditaR `12.4.1`
- Microsoft.AspNetCore.Authentication.JwtBearer `8.0.10`
- Microsoft.AspNetCore.Mvc.Testing `8.0.10`
- Microsoft.AspNetCore.OpenApi `8.0.5`
- Microsoft.EntityFrameworkCore `8.0.10`
- Microsoft.EntityFrameworkCore.InMemory `8.0.10`
- Microsoft.Extensions.Configuration.Abstractions `8.0.0`
- Microsoft.Extensions.Configuration.Binder `8.0.2`
- Moq `4.20.72`
- NUnit `3.14.0`
- NUnit.Analyzers `3.9.0`
- NUnit3TestAdapter `4.5.0`
- Swashbuckle.AspNetCore `6.9.0`