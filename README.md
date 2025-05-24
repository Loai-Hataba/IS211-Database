# IS211-Database: Movie Renting System

A database project for an online Movie Renting System. This application allows users to browse and rent movies, with all data managed via a connected Microsoft SQL Server database.
Note: Here is a more thorough indexing of the repo "https://deepwiki.com/Loai-Hataba/IS211-Database"

## Table of Contents

- [About](#about)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## About

This project implements a movie renting system as part of the IS211 course.  
Users can register, browse available movies, and rent them. Admins can add, update, and remove movies, as well as manage user data.  
The backend is connected to a Microsoft SQL Server database, which stores all essential data, including users, movies, admins, and rental records.

## Features

- User registration and authentication
- Browse/search available movies
- Rent and return movies
- Admin panel for managing movies and users
- Persistent storage of all data using Microsoft SQL Server

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (specify your version, e.g., .NET 6 or .NET 7)
- Microsoft SQL Server (local or remote)
- (Optional) SQL Server Management Studio or Azure Data Studio for database management

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Loai-Hataba/IS211-Database.git
   cd IS211-Database
   ```

2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

3. **Configure your database connection:**
   - Update the connection string in `appsettings.json` (or relevant config file) with your SQL Server details.

4. **Build the project:**
   ```bash
   dotnet build
   ```

5. **Apply database migrations** (if applicable):
   ```bash
   dotnet ef database update
   ```

6. **Run the application:**
   ```bash
   dotnet run
   ```

## Usage

- Register as a user or sign in as an admin.
- Browse the movie catalog, search, and filter results.
- Rent available movies and view your rental history.
- Admins can manage the movie collection and user base.

_If your project includes a UI, add screenshots or further instructions here. If it’s a backend API, consider adding example API requests and responses._

## Project Structure

```
IS211-Database/
├── src/                # Source code for application
├── Database/           # Database scripts or migrations
├── tests/              # Unit/integration tests
├── README.md
└── ...
```

_Adapt based on your actual repository structure._

## Contributing

Contributions are welcome! Please open issues or submit pull requests for any changes.

**How to contribute:**
1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/AmazingFeature`).
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a pull request.

## License

_No license has been specified. Please add a license if you intend to share or reuse this project._

## Contact

Project maintained by [Loai-Hataba](https://github.com/Loai-Hataba).

_For questions or suggestions, please open an issue on GitHub._

---
