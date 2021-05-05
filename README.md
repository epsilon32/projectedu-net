# projectedu-net
ProjectEdu .NET Core 5 version.
Application for exam creation, exam taking, score reports (other features pending)

---

### Development Information (add as needed)
 - Developed using Visual Studio 2019 ([link](https://visualstudio.microsoft.com/downloads/))
 - Uses .NET Core 5 (C#) ([link](https://dotnet.microsoft.com/download/dotnet/5.0))

### Project Structure (add as needed)
 - **Projectedu.API** : Web API
 - **Projectedu.API.Library** : Data Access Library for API
 - **Projectedu.DB** : Database Definition
 - **Projectedu.Desktopui** : WPF Desktop Interface

### Libraries Used (add as needed)
 1. Caliburn Micro ([link](https://caliburnmicro.com/)). An easier way to implement MVVM in WPF
 2. Dapper ([link](https://github.com/DapperLib/Dapper)). Micro Object Relational Mapping library.
 3. Autofac ([link](https://autofac.org/)). Dependency injection library (for use in API libary generally)

### How to Run (TODO)
Should be able to run by running both API and DesktopUI. API URL is set in DesktopUI/appsettings.json. DB connection string is in API/appsettings.json. Generate DB from DB project by publishing to local db (then set the connection string)