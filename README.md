# Modular-ASPNetCore-MVC-Template

A structured and modular ASP.NET Core MVC solution template built for clean separation of concerns, scalability, and easier maintenance.

This project originally started as an internal organizational template to help keep things consistent across solutions — but it's totally open for anyone to use or adapt if it fits their needs. It comes with a pre-organized architecture, working examples, and project layout that's ready to go out of the box.

---

## 📦 Structure Overview

```
Modular ASPNET Core MVC Template/
├── .template.config/              # Contains template.json for dotnet templating
│   └── template.json
├── MyApp.sln                      # Pre-configured solution file
├── MyApp.Common/                  # Shared constants and utilities
│   ├── UtilityConstants/
│   └── ValidationConstants/
├── MyApp.Data/                    # Data layer
│   ├── Database/
│   └── DataModels/
├── MyApp.Services/                # Service layer split into distinct responsibilities
│   ├── Abstractions/              # DTOs, API models, custom attributes
│   ├── CoreServices/              # Acts as a bridge layer between controllers and lower-level services. Handles
                                   # full operations like data updates and presentation logic coordination
│   ├── DataServices/              # Services responsible for data access (e.g., repositories)
│   ├── PresentationServices/      # Logic related to the web layer (view models, formatting)
│   └── UtilityServices/           # Helpers, converters, and general-purpose reusable logic
├── MyApp.Tests/                   # Unit and integration tests
│   └── Tests/
├── MyApp.Web/                     # Web/MVC project
│   ├── Application/
│   └── ViewModels/
├── restore-structure.ps1          # Restore folder structure on Windows
├── restore-structure.sh           # Restore folder structure on macOS/Linux
├── .git/
├── .idea/                         # Rider IDE config (optional)
├── .gitignore
└── README.md
```

> Each folder corresponds to a **distinct project** following the naming convention `MyApp.<ProjectName>` (e.g., `MyApp.Services.Abstractions`, `MyApp.Common.ValidationConstants`, `MyApp.Web.Application`) to enforce modularity and maintain a clean separation of concerns.

---

## 📁 Project Breakdown

### MyApp.Common
- **UtilityConstants**: Holds config keys, file paths, static settings (`ConfigurationConstants`), and status/error/log messages (`StatusMessages`).
- **ValidationConstants**: Contains data model constraints (`DataModelsConstants`) and format constants like date formats and regex (`FormatConstants`).

### MyApp.Data
- **Database**: `AppDbContext` (inherits `IdentityDbContext<ApplicationUser>`) with configurations and seeders.
- **Configurations**: DB table configurations (roles, relationships).
- **Seeding**: Seed data configurations.
- **DataModels**: Enums, mapping tables, and other database models.
- **ApplicationUser**: An extended Identity user class to allow adding custom properties beyond the default IdentityUser.

### MyApp.Services
- **Abstractions**: API models, DTOs, and custom attributes (includes essential `[AutoRegisterService]` attribute for DI auto-registration).

> **Note:** The `[AutoRegisterService]` attribute is used to automatically register services in the DI container. It should only be applied to classes that implement an interface, and specifies the service lifetime (Scoped, Transient, or Singleton). For example:

```csharp
[AutoRegisterService(ServiceLifetimeType.Scoped)]
public class BlogService : IBlogService
{
    // Implementation
}
````
- **CoreServices**: Acts as a bridge between controllers and data/presentation layers, handling workflows like data retrieval and presentation coordination.
- **DataServices**: Manages all database operations.
- **PresentationServices**: Services for views—formatting, populating viewmodels, etc.
- **UtilityServices**: Static helpers, converters, extensions, and reusable logic (no DI registration needed).

### MyApp.Tests
- Unit and integration tests using Moq, NUnit, and .NET SDK test templates.

### MyApp.Web
- **ViewModels**: All web app viewmodels.
- **Application**
    - `Areas`: Admin area with controllers and views.
    - `Extensions`:
        - `IdentityOptionsProvider`: Identity configuration.
        - `ServiceCollectionExtensions`: Predefined MVC service registrations.
        - `ApplicationBuilderExtensions`: Middleware additions using method chaining.

---

## 🚀 Getting Started

### 1. 📥 Clone the Repository

You can clone the repository using:

```bash
git clone https://github.com/OtakuDevs/Modular-ASPNetCore-MVC-Template.git
cd Modular-ASPNetCore-MVC-Template
```

---

### 2. 📦 Install the Template

Run the following command from the root of the project directory to install the template locally:

```bash
dotnet new --install .
```

---

### 3. 🛠️ Create a New Project from the Template

#### ✅ CLI Method (Recommended)

```bash
dotnet new modularmvc -n YourProjectName
cd YourProjectName
```

This will scaffold a fully modular project with the original folder and solution structure preserved.

#### ✅ Rider / Visual Studio UI (Manual Step Required)

If you use **Rider** or **Visual Studio** to create a new project from the template, the solution will be **flattened** (i.e., physical folder structure won't be preserved).

To restore the original structure, you can simply **right-click the script file for your OS and select "Run"**, which is the easiest way.

Or run the appropriate script from the command line:

**On Windows (PowerShell):**

```powershell
.\restore-structure.ps1
```

**On macOS/Linux (Bash):**

```bash
chmod +x restore-structure.sh
./restore-structure.sh
```


📌 **Note for Rider Users:**  
Scripts might not be visible in Solution Explorer by default. Use the **"Show All Files"** option to reveal untracked files in the project tree and include them if needed.

---

## 📌 Purpose and Philosophy

This template provides a clean architectural foundation for ASP.NET Core MVC applications, with:

- Modular project organization
- Clear separation of concerns
- Readable and scalable layout
- Example code for quick onboarding

---

## 💡 Future Improvements & Suggestions

This template is still evolving. If you have ideas or features you'd like to see added, feel free to open an issue or pull request — contributions and suggestions are always welcome!


---

## 🧩 Credits

Maintained by [OtakuDevs](https://github.com/OtakuDevs)  
Licensed under the MIT License.  
Free to use and modify in any personal or commercial projects.
