# Triangular Roof Block with Chimney — Volume Calculator

Web application built with **HTML** (interface) and **C# / ASP.NET Core 8** (calculation engine).

## Project structure
```
deliverables/
├── RoofBlockCalculator.csproj   <- .NET project file
├── Program.cs                   <- ASP.NET Core startup + /api/calculate endpoint
├── VolumeCalculator.cs          <- C# math (rectangular + triangular prism volumes)
├── Dockerfile                   <- For deploying to Render / Railway / Azure
└── wwwroot/
    └── index.html               <- Dark-blue UI; posts to /api/calculate
```

## Run locally (requires .NET 8 SDK)
```
cd deliverables
dotnet run
```
Then open http://localhost:8080 in your browser.

## How it works
1. The user enters dimensions in the HTML form.
2. JavaScript posts the values as JSON to `POST /api/calculate`.
3. The C# `VolumeCalculator` class computes V₁, V₂, V₃ and the total.
4. The result is returned as JSON and displayed in the result panel.
