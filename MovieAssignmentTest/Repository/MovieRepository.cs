using Microsoft.EntityFrameworkCore;
using MovieAssignmentTest.Models;

namespace MovieAssignmentTest.Repository
{
    // Create a MovieRepository.cs
    public class MovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieModel>> GetAllMoviesAsync()
        {
            return await _context.MovieModels.ToListAsync();
        }

        // Add methods for specific queries or updates
    }

}
