using APIMovies.DAL;
using APIMovies.DAL.Models;
using APIMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIMovies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> MovieExistByIdAsync(int id)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(x => x.Id == id);
        }
        public async Task<bool> MovieExistByNameAsync(string name)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(x => x.Name == name);
        }
        public async Task<bool> CrateMovieAsync(Movie movie)
        {
            movie.CreateDate = DateTime.UtcNow;
            await _context.Movies.AddAsync(movie);
            return await SaveAsync();
        }
        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;
            _context.Movies.Update(movie);
            return await SaveAsync();
        }
        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            if (movie == null)
            {
                return false; //La pelicula no existe
            }
            _context.Movies.Remove(movie);
            return await SaveAsync();
        }
        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
