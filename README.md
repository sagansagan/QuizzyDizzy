# Quiz Application

This project is a web application built using Blazor WebAssembly and ASP.NET Core with the new template "Blazor Web App". The application utilizes Entity Framework for data management and ASP.NET Identity for authentication and authorization.

## Table of Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [Features](#features)
- [Technologies Used](#technologies-used)

## Installation

1. Make sure you have the following:

    - .NET SDK installed

2. Clone the repository

## Configuration

1. Update the connection string in appsettings.json (in the project with name: QuizzyDizzy) to point to your database. The default configuration uses SQL Server.
2. Apply migrations to create the database schema.

   That is all.

## Project Structure
<ul>
 <li><strong>QuizzyDizzy.Client/:</strong> Contains the Blazor WebAssembly frontend application.</li>
 <li><strong>QuizzyDizzy.Shared/:</strong> Contains shared DTOs and utilities used by both client and server.</li>
 <li><strong>QuizzyDizzy/:</strong> Contains the ASP.NET Core backend application.</li>
 <li><strong>Controllers/:</strong> ASP.NET controllers for handling API requests.</li>
 <li><strong>Data/:</strong> Contains Entity Framework DbContext and migrations.</li>
 <li><strong>Models/:</strong> Entity classes and data models.</li>
</ul>

## Features 
<ul>
    <li><strong>Quiz Creation:</strong> Users can create quizzes with multiple questions. </li>
    <li><strong>Question Types:</strong> Supports multiple choice and free text questions. </li>
    <li><strong>Media Support:</strong> Questions can include images or YouTube videos.</li>
    <li><strong>Time Limits:</strong> Set a time limit for each question.</li>
    <li><strong>Quiz Results:</strong> Track and display results for users who take the quizzes.</li>
    <li><strong>Entity FrameWork:</strong> For database operations.</li>
    <li><strong>Blazor Frontend:</strong> Modern single-page application (SPA) using Blazor.</li>
    <li><strong>Protected Routes:</strong> Certain routes are accessible only to authenticated users.</li>
    <li><strong>Authentication and Authorization:</strong> Uses ASP.NET Identity for user management.</li>
</ul>

## Technologies Used
<ul>
    <li><strong>.NET 8</strong>
    <li><strong>ASP.NET Core:</strong> Web framework for building web applications.</li>
    <li><strong>Entity Framework Core:</strong> ORM for database management.</li>
    <li><strong>ASP.NET Identity:</strong> Authentication and authorization.</li>
    <li><strong>Blazor Webbassembly:</strong> Frontend framework for building interactive web UIs.</li>
    <li><strong>SQL Server:</strong> Default database (can be changed in configuration).</li>
</ul>

Enjoy creating and taking quizzes!
