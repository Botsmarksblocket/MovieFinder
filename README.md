![Blazor](https://img.shields.io/badge/Blazor-512BD4?style=flat&logo=blazor&logoColor=white)
![MudBlazor](https://img.shields.io/badge/MudBlazor-593D88?style=flat&logo=materialdesign&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-5C2D91?style=flat&logo=dotnet&logoColor=white)
# MovieFinder

MovieFinder is a web application built with Blazor WebAssembly and .NET 9, designed to help users search and discover movies efficiently using The Movie Database API. 
## Solution Overview

The solution is organized into three projects.

### 1. MovieFinder.Client (frontend)
- **Type:** Blazor WebAssembly
- **Purpose:** The front-end application where users interact with the MovieFinder UI.
- **Features:** 
  - Responsive UI with MudBlazor components
  - Movie search and display functionality
  - Custom styling and loading indicators
  - Custom-built infinite scrolling component to seamlessly deliver movies

### 2. MovieFinder.API (backend)
- **Type:** ASP.NET Core Web API
- **Purpose:** The backend service that exposes RESTful endpoints for movie data. Handles requests from the Blazor client and serves movie information.
- **Features:**
  - .NET 9 support
  - Movie Data Endpoints: Exposes endpoints for searching, retrieving, and filtering movie information.
  - Integration with shared models

### 3. MovieFinder.Shared
- **Type:** .NET Class Library
- **Purpose:** Contains shared models and logic used by both the client and API projects. Ensures consistency in data structures and reduces duplication.
- **Features:**
  - Shared DTOs and data contracts
  - Common utilities
# Images
<img width="2535" height="1302" alt="image" src="https://github.com/user-attachments/assets/bd734299-1ca8-4b3e-aa9e-e42bf991abf4" />
<img width="2538" height="1297" alt="image" src="https://github.com/user-attachments/assets/bfd298c2-33f5-4189-8688-edbd4f3f9a12" />
<img width="2534" height="1297" alt="image" src="https://github.com/user-attachments/assets/abf83de0-c16e-4203-8d27-de43d63e88ec" />
<img width="2532" height="1297" alt="image" src="https://github.com/user-attachments/assets/b3e7e1ed-9a59-4627-8b51-39033365fff9" />
<img width="551" height="1164" alt="image" src="https://github.com/user-attachments/assets/ede579f7-13b9-4917-8846-f410e8e4de1c" />
