---

```markdown
# 📚 Library Management System (LMS)

A modern **C# Windows Forms Application** for managing a library's books, borrowers, and staff accounts — built with **.NET Framework 4.7.2** and **SQL Server**.

---

## 🚀 Features

### 👨‍💼 Staff Management
- Create, edit, and delete staff accounts.
- Secure login with username and password.
- Role-based access (Admin / Librarian).

### 📖 Book Management
- Add, edit, delete, and search books.
- Auto-refresh data grid when new books are added.
- Real-time SQL dependency updates (via `SqlDependency`).

### 🔁 Borrow & Return
- Manage borrowed books and return records.
- Tracks which staff handled transactions.

### 🏠 Dashboard & UI
- Clean sidebar navigation (`Home`, `Books`, `Borrow/Return`, `Staff`).
- Role-based button visibility (Admin can manage staff).
- Resizable and draggable borderless form.
- Integrated icons and modern design.

---

## 🧱 Project Structure

```

LMS/
│   LMS.sln
│   Program.cs
│   App.config
│   README.md
│
├───Core/
│   ├───Connection.cs          # Database connection class
│   └───App.cs                 # Main application entry logic
│
├───Forms/
│   ├───Login/                 # Login form (authentication)
│   ├───Books/                 # Manage book records
│   ├───BorrowReturn/          # Borrow & Return functionality
│   ├───Staff/                 # Manage staff accounts
│   └───Welcome/               # Default welcome dashboard
│
├───images/                    # All icons and UI resources
│
├───_db/
│   └───db_sqlserver.sql       # SQL script for database creation
│
└───bin/Debug/SQL/
└───MAKE_DATABASE.TXT      # Notes for enabling Service Broker

```

---

## ⚙️ Setup Instructions

### 🧩 Prerequisites
- **Windows 10/11**
- **SQL Server** (LocalDB, Express, or Full)
- **Visual Studio 2019/2022**
- **.NET Framework 4.7.2**

---

### 🔧 Step 1 — Database Setup

1. Open SQL Server Management Studio (SSMS).
2. Run the script:
```

_db/db_sqlserver.sql

````
3. Make sure **Service Broker** is enabled:
```sql
ALTER DATABASE LMS_DB SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE;
````

4. Update your connection string in:

   ```
   Core/Connection.cs
   ```

   Example:

   ```csharp
   public static SqlConnection GetConn()
   {
       return new SqlConnection("Data Source=.;Initial Catalog=LMS_DB;Integrated Security=True");
   }
   ```

---

### 🖥️ Step 2 — Run the Application

1. Open `LMS.sln` in Visual Studio.
2. Set **LMS** as the startup project.
3. Build the project (`Ctrl + Shift + B`).
4. Run (`F5`).

✅ Login with an existing user (from your SQL data) or manually insert one:

```sql
INSERT INTO Staff (FullName, Email, Phone, Role, Username, Password, CreatedAt)
VALUES ('Admin User', 'admin@lms.com', '012345678', 'Admin', 'admin', '123', GETDATE());
```

---

### 🧠 Step 3 — Default Roles

| Role          | Permissions                               |
| ------------- | ----------------------------------------- |
| **Admin**     | Full access (Books, Borrow/Return, Staff) |
| **Librarian** | Manage Books and Borrow/Return only       |

---

## 🧩 Technologies Used

| Category        | Tool / Framework                        |
| --------------- | --------------------------------------- |
| Language        | C# (.NET Framework 4.7.2)               |
| Database        | Microsoft SQL Server                    |
| UI              | WinForms                                |
| ORM / DB Access | ADO.NET (`SqlConnection`, `SqlCommand`) |
| Notifications   | `SqlDependency` for real-time updates   |
| Design          | Custom icons, image-based buttons       |

---

## 📸 Screenshots (Optional)

Add your screenshots here (e.g. login screen, dashboard, staff management).

```
![Login Form](images/login_preview.png)
![Dashboard](images/dashboard_preview.png)
```

---
