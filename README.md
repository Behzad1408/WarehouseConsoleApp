# Warehouse Console Application

This is a simple C# console application designed to manage a basic warehouse system. The app handles operations related to products, categories, transactions, and warehouse storage.

## 📁 Project Structure

```
WarehouseConsoleApp-main/
├── ConsoleAppWarehouse2025.sln         # Visual Studio Solution File
├── README.md                           # Project Documentation
├── .gitignore
├── .gitattributes
└── ConsoleAppWarehouse2025/
    ├── Program.cs                      # Main program logic
    ├── Product.cs                      # Product model
    ├── Category.cs                     # Category model
    ├── Transaction.cs                  # Transaction model
    ├── Warehouse.cs                    # Warehouse class for managing operations
    └── ConsoleAppWarehouse2025.csproj  # C# project file
```

## ⚙️ Features

- Add and manage product categories
- Add and update warehouse products
- Record product transactions
- Basic in-memory data handling (no database)

## 🛠️ Technologies Used

- C# (.NET)
- Console Application (CLI)
- Object-Oriented Programming (OOP)

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (version 6.0 or newer recommended)
- Visual Studio or any C# IDE

### How to Run

1. Clone the repository:

```bash
git clone https://github.com/your-username/WarehouseConsoleApp.git
cd WarehouseConsoleApp/ConsoleAppWarehouse2025
```

2. Run the project using the .NET CLI:

```bash
dotnet run
```

## 📌 Notes

- All data is stored in memory during runtime and is lost after the program closes.
- Great starting point for adding database support (e.g., SQLite, SQL Server) or converting to a web API.

---
