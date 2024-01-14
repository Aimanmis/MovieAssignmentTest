using MovieAssignmentTest.Models;
using MovieAssignmentTest.Repository;

namespace MovieAssignmentTest.Services
{
    // Create a MovieService.cs
    public class MovieService
    {
        private readonly MovieRepository _repository;

        public MovieService(MovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MovieModel>> GetAllMoviesAsync()
        {
            return await _repository.GetAllMoviesAsync();
        }

        // Add methods for specific business logic
    }

}
