# Task Team Management System 

A **.NET 9 Web API** project designed to manage projects, tasks, and team members with role-based authorization and clean architecture principles.  
The system allows team leaders to create and manage projects, while team members can collaborate by handling tasks effectively.  

---

## 🚀 Features

- **Authentication & Authorization**
  - ASP.NET Core Identity for user management.
  - Role-based access (`User`, `TeamLeader`).
- **Projects Management**
  - Create, update, delete, and view projects.
  - The creator of a project automatically becomes the **leader** of that project.
  - Retrieve projects where the user is a member.
- **Tasks Management**
  - Create, update, delete, and view tasks within a project.
  - Tasks are linked to a project and assigned to members.
- **Team Collaboration**
  - Users can join multiple projects.
  - Leaders can manage members and tasks within their projects.
- **Entity Relationships**
  - `Project` ↔ `Task` (One-to-Many).
  - `User` ↔ `Project` (Many-to-Many).
  - `User` ↔ `Task` (One-to-Many, optional).
- **Clean Architecture & Best Practices**
  - Repository & Unit of Work patterns.
  - Dependency Injection throughout the project.
  - Separation of concerns across layers.

---

## 🏗️ Project Structure

```
TaskTeamManagementSystem/
│── src/
│   ├── TaskTeamManagementSystem.Api/            # Presentation Layer (Controllers, Middlewares, Configs)
│   ├── TaskTeamManagementSystem.Application/    # Application Layer (DTOs, Services, Interfaces)
│   ├── TaskTeamManagementSystem.Domain/         # Domain Layer (Entities, Enums, Exceptions)
│   ├── TaskTeamManagementSystem.Infrastructure/ # Infrastructure Layer (EF Core, Repositories, Identity)
│
│── .gitignore
│── README.md
```

---

## 🗄️ Database Schema

### Entities:
- **User (Identity)**
  - Extended with navigation properties for Projects and Tasks.
- **Project**
  - `Id`, `Name`, `Description`, `LeaderId`, `CreatedAt`, `UpdatedAt`.
- **Task**
  - `Id`, `Title`, `Description`, `Status`, `ProjectId`, `AssignedUserId`.

### Relationships:
- A **Project** has many **Tasks**.
- A **User** can be a **Leader** of one or more Projects.
- A **User** can be a **Member** of many Projects.
- A **Task** belongs to a Project and can be assigned to a User.

---

## ⚙️ Technologies Used

- **Backend:** ASP.NET Core 9 Web API
- **Database:** Microsoft SQL Server with Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Design Pattern:** Repository Pattern, Unit of Work
- **Architecture:** Clean Architecture
- **Version Control:** Git & GitHub
- **Tools:** Visual Studio / Rider / VS Code, Postman, GitHub Projects

---

## 📝 API Endpoints (Overview)

### Authentication
- `POST /api/auth/register` → Register new user
- `POST /api/auth/login` → Login and get JWT token

### Projects
- `POST /api/projects` → Create new project (logged-in user becomes leader)
- `GET /api/projects/{id}` → Get project details
- `GET /api/projects` → Get all projects where the user is member or leader
- `GET /api//project/{projectId}/tasks` → Get all tasks in a project
- `PUT /api/projects/{id}` → Update project
- `DELETE /api/projects/{id}` → Delete project

### Tasks
- `POST /api/tasks/{projectId}` → Create task in a project
- `GET /api/tasks/{id}` → Get task details
- `PUT /api/tasks/{projectId}/{id}` → Update task
- `DELETE /api/tasks/{projectId}/{id}` → Delete task

---
## 🏷️ Versioning

We use **Git tags** for releases:
- `v1.0.0` → MVP with authentication, projects, and tasks CRUD.
- Upcoming versions will include notifications, task comments, and more.

---

## 📌 Roadmap

- [x] Authentication & Identity
- [x] CRUD for Projects & Tasks
- [x] Role-based Authorization
- [ ] Task assignment notifications
- [ ] File attachments in tasks
- [ ] Project activity logs
- [ ] Real-time updates with SignalR

---

## 📜 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.
