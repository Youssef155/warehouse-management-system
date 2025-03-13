# Warehouse Management System

## Project Description
The **Warehouse Management System (WMS)** is a comprehensive software solution designed to manage warehouse operations efficiently for a trading company. It helps streamline item management, inventory tracking, order processing, and reporting.

The system provides the following key features:
- **Warehouse Management:** Create, update, and delete warehouses.
- **Item Management:** Manage items with support for multiple units (e.g., Kilogram and Box).
- **Supplier and Customer Management:** Track supplier and customer information.
- **Supply and Withdrawal Orders:** Record and manage supply and withdrawal of items from warehouses.
- **Stock Transfers:** Transfer items between warehouses while preventing expired items from being moved.
- **Reports:** Generate detailed reports such as warehouse status, item movements, and expiration tracking.
- **Exportable Reports:** Reports can be exported as PDF files for easy sharing and documentation.

---

## Tech Stack
- **.NET Framework:** Backend logic and business layer.
- **C# WinForms:** Desktop UI for interactive management.
- **Entity Framework Core:** Data access and ORM.
- **SQL Server:** Relational database management.
- **RDLC Reports:** Reporting and PDF generation.

---

## Architecture and Design Patterns
The application follows a modular and maintainable architecture using the following design patterns:
- **N-Tier Architecture:** Separation of Presentation, Business, and Data Access layers.
- **Repository Pattern:** Abstracts data access logic.
- **Unit of Work Pattern:** Ensures atomic operations for data persistence.
- **Service Layer:** Centralized business logic and orchestration.

### Project Structure
```
WarehouseManagementSystem/
├── WarehouseManagementSystem.Data/         # Data Access Layer
│   ├── Models/                             # Database Models
│   ├── Repositories/                       # Repository Implementations
│   ├── UOW/                                # Unit of Work Pattern
│   └── Migrations/                         # Database Migrations
├── WarehouseManagementSystem.Business/     # Business Logic Layer
    ├── Interfaces/                         # Interface for each service
│   └── Services/                           # Business Services
├── WarehouseManagementSystem.Presentation/ # Presentation Layer (WinForms)
│   ├── Forms/                              # UI Forms for each feature
|   ├── ReportDataSets/                     # Dataset for each Report to represent the data
│   └── Reports/                            # RDLC Report Templates
└── WarehouseManagementSystem.Core/         # DTOs for separation of concerns
│   └── DTOs/     
```

---

## How to Run the Project
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Update the database connection string in the `appsettings.json` file.
4. Open Package Manager Console and run `Update-Database` command. 
5. Run the project to launch the WinForms application.
6. Navigate through the UI to manage warehouses, items, orders, and generate reports.

---

## Reporting
The system includes the following reports:
1. **Warehouse Status Report:** Shows all items in a selected warehouse.
2. **Items in Warehouse for a Period of Time:** Lists items stored for a specified duration.
3. **Stock Transfers Report:** Tracks the movement of items between warehouses.
4. **Items Close to Expiration Report:** Lists items that are nearing expiration within a specified time frame.

Reports are generated as PDF files and saved to the local filesystem.


