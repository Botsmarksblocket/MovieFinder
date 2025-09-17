[![Live Demo](https://img.shields.io/badge/Live%20Demo-brightgreen?style=for-the-badge)](https://www.moviefinderapp.com/)

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

