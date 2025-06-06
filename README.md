# Modular-ASPNetCore-MVC-Template

A structured and modular ASP.NET Core MVC solution template built for clean separation of concerns, scalability, and easier maintenance.

This project originally started as an internal organizational template to help keep things consistent across solutions — but it's totally open for anyone to use or adapt if it fits their needs. It comes with a pre-organized architecture, working examples, and project layout that's ready to go out of the box.

---

## 📦 Structure Overview

```
Modular ASPNET Core MVC Template/
├── .template.config/                # Contains template.json for dotnet templating
│   └── template.json
├── MyApp.sln                        # Pre-configured solution file
├── MyApp.Common/                   # Shared constants and utilities
│   ├── UtilityConstants/
│   └── ValidationConstants/
├── MyApp.Data/                     # Data layer
│   ├── Database/
│   └── DataModels/
├── MyApp.Services/                 # Service layer split into distinct responsibilities
│   ├── Abstractions/              # DTOs, API models, custom attributes
│   ├── CoreServices/              # Acts as a bridge layer between controllers and lower-level services; handles full operations like data updates and presentation logic coordination
│   ├── DataServices/              # Services responsible for data access (e.g., repositories)
│   ├── PresentationServices/      # Logic related to the web layer (view models, formatting)
│   └── UtilityServices/           # Helpers, converters, and general-purpose reusable logic
├── MyApp.Tests/                    # Unit and integration tests
│   └── Tests/
├── MyApp.Web/                      # Web/MVC project
│   ├── MyApp/
│   └── ViewModels/
├── restore-structure.ps1           # Restore folder structure on Windows
├── restore-structure.sh            # Restore folder structure on macOS/Linux
├── .git/
├── .idea/                          # Rider IDE config (optional)
├── .gitignore
└── README.md
```

> Each subfolder under `MyApp.Services/` corresponds to a **distinct project** (e.g., `MyApp.Services.Abstractions`, `MyApp.Services.CoreServices`, etc.) to enforce modularity and maintain clean separation of logic.

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

To restore the original structure, run the appropriate script:

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
