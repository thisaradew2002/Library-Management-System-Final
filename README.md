# 📚 Library Management System (Desktop Application)

A comprehensive Desktop-based **Library Management System** developed using **C#** and **MS SQL Server Management Studio (SSMS)**. This system is designed with specific business logic to automate library operations, tracking book issues, returns, and fine limitations for students.

---

## 🚀 Key Features

### 👤 User (Student) Module
* **Self-Registration:** New students can register themselves into the system.
* **Smart Status Check:** By simply entering their **Enrollment Number**, students can instantly view their pending returns.

### ⚡ Admin (Librarian) Module
* **Book & Student Management:** Full CRUD operations to **Add, View, Manage and Search** books and student profiles.
* **Book Issuing Logic:** Admins can issue books to students with a built-in strict restriction: **Maximum of 3 books per student at any given time**.
* **Book Returns:** Efficiently handle returned books and update availability status instantly.
* **Comprehensive Reporting:** A dedicated reports section to view all historical data regarding issued books, successfully returned books, and pending returns.

---

## 🛠️ Technologies Used

* **IDE:** Visual Studio
* **Language:** C# (.NET Framework / Windows Forms)
* **Database:** MS SQL Server (SSMS)
* **Architecture:** Object-Oriented Programming (OOP)

---

## 📂 Project Configuration & Database Setup

The project includes the C# source code solution alongside the database backup script:
* Contains all `.cs` forms, business logic classes, and UI layouts.
* Contains the `.sql` database script generated from SQL Server Management Studio.

---

## 💻 How to Setup Locally

1. **Clone or Download** this repository.
2. Open **Microsoft SQL Server Management Studio (SSMS)**.
3. Create a new database named `LibraryDB` (or your preferred name).
4. Open the provided `.sql` database script in SSMS, and click **Execute** to generate the tables and stored procedures.
5. Update the **Database Connection String** inside the C# project (`App.config` or connection class) with your local SQL Server credentials.
6. Open the project solution (`.sln`) in **Visual Studio** and click **Start/Run**.
  
