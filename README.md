# 💊 MediVault - Medicine Management System

A Single Page Application built using ASP.NET Core Web API and Angular to manage medicines. The application allows users to add medicines, view them in a grid, search by medicine name, and identify medicines that are expiring soon or have low stock.

## Features

* View all medicines
* Add a new medicine
* Search medicines by name
* Highlight medicines:

  * 🔴 Red: Expiry date within 30 days
  * 🟡 Yellow: Quantity less than 10
* JSON file storage (no database)
* Responsive Angular UI

## Tech Stack

### Backend

* ASP.NET Core 8 Web API
* C#
* Repository Pattern
* Dependency Injection
* JSON File Storage

### Frontend

* Angular 19
* Standalone Components
* Reactive Forms
* HttpClient

## Project Structure

```text
MedicineManagementSystem
│
├── MedicineManagement.Api
│   ├── Controllers
│   ├── Repositories
│   ├── Entities
│   ├── Data
│   └── Program.cs
│
└── medicine-management-ui
    ├── core
    ├── features
    ├── models
    └── shared
```

## Prerequisites

* .NET 8 SDK
* Node.js 22 LTS (recommended)
* Angular CLI

## Run the Backend

```bash
cd MedicineManagement.Api
dotnet restore
dotnet run
```

Backend URL

```text
http://localhost:5141
```

Swagger

```text
http://localhost:5141/swagger
```

## Run the Frontend

```bash
cd medicine-management-ui
npm install
ng serve
```

Frontend URL

```text
http://localhost:4200
```

## Application Features

* Add Medicine
* View Medicine List
* Search Medicines
* JSON Persistence
* Expiry Highlighting
* Low Stock Highlighting

## Author
Prabhat Chand
