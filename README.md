
# Flight Booking System Documentation

## Overview
This project is an online flight booking system built with ASP.NET Core MVC. It allows users to book flights, view available flights, and manage their bookings. The system uses Entity Framework Core for data access and LINQ for querying the database.

## Technologies Used
- **ASP.NET Core MVC**: For building the web application with a clean MVC architecture.
- **Entity Framework Core**: For data access and ORM to interact with the database.
- **LINQ**: For querying and manipulating data from the database.

## Features
- User registration and authentication.
- Flight search and booking functionality.
- Viewing available flights and flight details.
- Managing bookings and viewing booking history.

## Database Schema
The database consists of the following main entities:
- **Flight**: Stores flight details such as flight number, departure and arrival locations, departure and arrival times, and seat availability.
- **Booking**: Stores booking details such as the user, flight, booking date, and booking status.
- **User**: Represents the customer who is booking the flights. Includes user details like name, email, and password.

## Setup Instructions
### Prerequisites
- .NET 6.0 or higher
- SQL Server or any other supported database

### Steps to Run the Project
1. Clone the repository.
2. Open the project in Visual Studio or your preferred IDE.
3. Restore the NuGet packages by running the following command in the terminal:
   ```
   dotnet restore
   ```
4. Apply the migrations to the database:
   ```
   dotnet ef database update
   ```
5. Run the project locally:
   ```
   dotnet run
   ```

### Configuration
- The database connection string and other settings are configured in the `appsettings.json` file.
- Ensure the database is set up correctly before running the application.


## Contributing
If you'd like to contribute to this project, feel free to fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License.

