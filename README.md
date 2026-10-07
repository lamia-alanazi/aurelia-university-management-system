# Aurelia University Management System

An academic university management web application built with C#, ASP.NET MVC 5, Entity Framework 6, and SQL Server LocalDB.

## Features

- Manage students, teachers, courses, and rooms.
- View academic profiles and course and room details.
- Administrator login with session-based access control.
- Restrict student pages and create, edit, and delete operations to administrators.
- Verify administrator passwords using salted PBKDF2 hashes.
- Render the interface with Razor views, Bootstrap, CSS, and JavaScript.

## Technology

| Component | Version in project |
| --- | --- |
| .NET Framework | 4.7.2 |
| ASP.NET MVC | 5.2.7 |
| Entity Framework | 6.1.3 |
| Bootstrap | 3.4.1 |
| jQuery | 3.4.1 |
| Database | SQL Server LocalDB |

## Project structure

- `Controllers/`: request handling and management operations.
- `Models/`: entities, database context, and password hashing.
- `Views/`: Razor pages and shared layouts.
- `Filters/`: administrator authorization filter.
- `Migrations/`: database schema changes and seed data.
- `App_Start/`: routing, filters, and asset bundles.
- `Content/`, `Scripts/`, `fonts/`, `images/`: interface assets.

## Local development

This is a classic ASP.NET MVC application targeting .NET Framework, rather than ASP.NET Core. Use a Windows development environment with Visual Studio, ASP.NET web development tools, the .NET Framework 4.7.2 targeting pack, and SQL Server LocalDB.

1. Open `lamia12771.sln`.
2. Restore the NuGet packages listed in `packages.config`.
3. Review the `SchoolContext` connection in `Web.config`. It uses the local `MSSQLLocalDB` instance with Windows authentication.
4. Use a new, disposable development database. Database initialization is currently incomplete; resolve the limitations below before expecting a fully working installation.
5. After database initialization is corrected and tested, build the solution and run it with IIS Express.

## Current limitations

- The supplied migrations do not create the `Admins` table. The `SyncAdmins` migration has empty `Up` and `Down` methods.
- No initial administrator creation workflow was found. Login requires an existing administrator record with a password hash and salt. Do not publish real login credentials.
- Seed logic removes selected legacy courses; do not run it against a valuable database.
- Some seeded student and room image paths do not match the supplied asset filenames.
- A clean database installation and application build have not yet been verified.
- Dependency security and production deployment hardening have not been audited.

Database backups, local IDE settings, and build output are intentionally excluded from the planned repository. The project owner has confirmed that student and teacher names, email addresses, academic details, and portraits are fictional demonstration data. Image licensing has not been independently verified.

## Project status

Academic portfolio project. Setup documentation is provisional until a clean Windows installation has been tested.
