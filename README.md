Movie RESTful API Service
This project is a Movie RESTful API service implemented in C# with a SQL Server database. It adheres to RESTful guidelines, includes request validation, unit tests, and additional features such as architectural improvements and elegant error handling.

RESTful Specifications
Endpoints:

GET /api/Movie: Get a list of movies.
GET /api/Movie/{id}: Get details of a specific movie.
POST /api/Movie: Create a new movie.
PUT /api/Movie/{id}: Update details of a specific movie.
DELETE /api/Movie/{id}: Delete a specific movie.
Response Object: The API uses the MovieModel object for requests and responses.

Language & Database: C# with SQL Server database.

Request Validation: Request validation ensures the integrity of incoming data.

Unit Tests: Unit tests are implemented for the MovieService using xUnit.

Extras:

Architectural Improvements: MVC pattern and service layer for better separation of concerns.
Error Handling: Provides meaningful responses for different scenarios.

Setup Instructions

Clone the repository:
git clone https://github.com/yourusername/MovieAssignmentTest.git

Navigate to the project directory:
cd MovieAssignmentTest
Update the database connection string in appsettings.json.

Run the application:
dotnet run
Access the API at https://localhost:5001/swagger/index.html.

Running Unit Tests
Navigate to the UnitTestMovieAssigment directory:
cd UnitTestMovieAssigment

Run the tests:
dotnet test

Additional Information
Swagger Documentation: Swagger documentation is available at https://localhost:5001/swagger/index.html.
Error Handling: The API provides detailed error messages for various scenarios.
Feel free to explore and extend this Movie RESTful API service!
