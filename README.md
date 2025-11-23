# 🎓 EduAll - Learning Management System (LMS)

EduAll is a comprehensive LMS platform built with **ASP.NET Core MVC**, designed to manage online courses, students, instructors, quizzes, and payments.

## 🚀 Tech Stack

* **Framework:** ASP.NET Core MVC (.NET 8)
* **Database:** SQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Authentication:** ASP.NET Core Identity (Customized `AppUser`)
* **Pattern:** Repository Pattern & Unit of Work
* **Front-End:** Custom HTML/CSS/JS Templates (EduAll for Users, Edmate for Admin)

---

## 🛠️ Getting Started

Follow these steps to set up the project locally.

### 1. Prerequisites
Make sure you have the following installed:
* [Visual Studio 2022](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload).
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or Developer Edition).
* .NET 8.0 SDK.

### 2. Clone the Repository
```bash
git clone <YOUR_REPO_URL_HERE>
cd EduAll
```
### 3. Configure Database
Open appsettings.json and update the connection string to match your local SQL Server instance:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EduAll_Db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```
### 4. Create Database (Migrations)
Since the project uses Code-First with Identity and complex relationships, you must apply migrations to create the database schema.

Open Package Manager Console (PMC) in Visual Studio and run:
```bash
Update-Database
```
## 📂 Project Structure & Key Features
### 1. Admin Dashboard (Areas)
The control panel is separated into an MVC Area to keep logic clean.

* Admin URL: /Admin or /Admin/Home/Index

* Layout: _AdminLayout.cshtml located in Areas/Admin/Views/Shared.

* Assets: Admin-specific CSS/JS files are in wwwroot/Admin/assets.

* **Note**: The Admin layout manages its own scripts. Do NOT uncomment the default libraries in the layout file to avoid conflicts (e.g., Dropdowns not working).

## 2. Authentication & Roles
* We extended the standard IdentityUser to a custom AppUser class to include:

* **Profile Data**: FirstName, LastName, Country, and Bio.

* **Link**s: Social Media links stored as JSON/Strings.

* **Roles**: The system supports Student, Instructor, and Admin.

## 3. Database Logic (The "Business Rules")
* **Cart System**:

* The cart is strictly for Courses (Digital Products).

* There is no "Quantity" field in CartItems.

* OrderItem stores the PriceAtPurchase to preserve financial history even if the course price changes later.

* **Quiz System**:

* Quizzes are linked to Sections (not Lessons).

* Hierarchy: Course -> Section -> Quiz -> Questions -> AnswerOptions.

* Student submissions are tracked in QuizSubmission with detailed StudentAnswers.

* **Enrollment**:

* Separate from "Orders". Enrollment tracks learning progress (ProgressPercent) and access rights

## 🤝 Contribution Guidelines (For the Team)
   1- **No Direct Commits**: Never push directly to the main or master branch.

   2- **Branching**: Create a new branch for every task or feature.

```bash
git checkout -b feature/your-task-name
```
   3- **Database Changes**:

  *  If you modify any Model (.cs file in Domain), you MUST create a migration.

  *  **Command**: Add-Migration DescriptionOfChange -> Update-Database.

  *  **Warning**: If you face "Multiple Cascade Paths" errors, check OnModelCreating in ApplicationDbContext and ensure OnDelete(DeleteBehavior.Restrict) is applied where necessary.

   4- **Pull Requests**: Push your branch and open a Pull Request (PR) for review.

   ذذ
