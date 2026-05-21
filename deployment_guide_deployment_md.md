# DEPLOYMENT.md

## Salon Management System Deployment Guide

### Project Overview
The **Salon Management System** is a desktop-based application developed using **C# (.NET Framework)** with **Windows Forms** and **MySQL** database support. This guide explains how to deploy and run the project on another machine successfully.

---

# 1. System Requirements

## Hardware Requirements
- Processor: Intel Core i3 or above
- RAM: Minimum 4 GB
- Storage: Minimum 40 GB free disk space
- Input Devices: Keyboard and Mouse
- Display: Standard Monitor

---

## Software Requirements

| Component | Requirement |
|---|---|
| Operating System | Windows 7 / 8 / 10 / 11 |
| Framework | .NET Framework 4.7.2 or above |
| IDE (Optional) | Visual Studio 2019/2022 |
| Database System | MySQL Server 8.0+ |
| Database Tool | MySQL Workbench |
| Language | C# |
| Additional Dependency | MySQL Connector for .NET |

---

# 2. Required Software Installation

## Step 1: Install Visual Studio
Download and install Visual Studio Community Edition:

https://visualstudio.microsoft.com/

During installation:
- Select **.NET Desktop Development**
- Ensure Windows Forms support is included

---

## Step 2: Install .NET Framework
Install .NET Framework 4.7.2 or newer:

https://dotnet.microsoft.com/en-us/download/dotnet-framework

---

## Step 3: Install MySQL Server
Download and install MySQL Server:

https://www.mysql.com/downloads/

While installing:
- Choose **Developer Default**
- Set a root password
- Keep default port `3306`

---

## Step 4: Install MySQL Workbench
Install MySQL Workbench for database management:

https://dev.mysql.com/downloads/workbench/

---

## Step 5: Install MySQL Connector for .NET
Install MySQL Connector to connect C# application with MySQL database:

https://dev.mysql.com/downloads/connector/net/

---

# 3. Project Installation Steps

## Step 1: Extract Project Files
- Copy the project ZIP file to the target machine
- Extract the ZIP file

Example:

```text
salon-management-system.zip
```

---

## Step 2: Open Project in Visual Studio
1. Open Visual Studio
2. Click **Open a Project or Solution**
3. Browse to the extracted project folder
4. Open the `.sln` file

---

## Step 3: Restore Dependencies
If Visual Studio prompts for missing packages:
- Click **Restore Packages**
- Build the solution once

---

# 4. Database Setup & Migration

## Step 1: Create Database
Open MySQL Workbench and execute:

```sql
CREATE DATABASE salon_management_system;
```

---

## Step 2: Import Database Script
If a `.sql` database file is included:

1. Open MySQL Workbench
2. Go to:
   - Server → Data Import
3. Select the provided SQL file
4. Import the database

---

## Step 3: Configure Connection String
Open the project and locate the database connection string in:

```text
App.config
```

Update it according to your MySQL setup:

```xml
server=localhost;
port=3306;
database=salon_management_system;
uid=root;
pwd=yourpassword;
```

Replace:
- `yourpassword` with your MySQL password

---

# 5. Running the Application

## Step 1: Build the Project
In Visual Studio:

```text
Build → Build Solution
```

Shortcut:

```text
Ctrl + Shift + B
```

---

## Step 2: Run the Application

Click:

```text
Start
```

or press:

```text
F5
```

The Salon Management System should launch successfully.

---

# 6. Default Login Credentials

If login authentication is enabled, use:

| Username | Password |
|---|---|
| urwa | 1234 |

---

# 7. Cross-Platform Compatibility

## Current Compatibility
The project is developed using:
- Windows Forms
- .NET Framework

Therefore, it is officially supported on:
- Windows 7
- Windows 8
- Windows 10
- Windows 11

---

## Bonus Compatibility Note
The application can run on different Windows versions successfully as long as:
- .NET Framework is installed
- MySQL Server is properly configured

---

# 8. Troubleshooting

## Issue: MySQL Connection Error
### Solution
- Ensure MySQL Server is running
- Verify username/password
- Check port `3306`

---

## Issue: Missing DLL Errors
### Solution
- Restore NuGet packages
- Rebuild solution

---

## Issue: Application Does Not Start
### Solution
- Verify .NET Framework installation
- Rebuild project in Visual Studio

---

# 9. Deployment Verification Checklist

| Task | Status |
|---|---|
| Visual Studio Installed | ✓ |
| .NET Framework Installed | ✓ |
| MySQL Server Installed | ✓ |
| Database Imported | ✓ |
| Connection String Updated | ✓ |
| Project Builds Successfully | ✓ |
| Application Runs Successfully | ✓ |

---

# 10. Conclusion

Following this deployment guide allows the Salon Management System to run successfully on another machine outside the development environment. The guide includes complete environment setup instructions, database migration steps, dependency installation, and execution procedures to ensure smooth deployment.

