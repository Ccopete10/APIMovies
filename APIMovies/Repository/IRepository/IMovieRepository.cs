using APIMovies.DAL.Models;

namespace APIMovies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //Retorna una lista de peliculas
        Task<Movie> GetMovieByIdAsync(int id); //Retorna una pelicula por Id
        Task<bool> MovieExistByIdAsync(int id); //Me dice si existe una pelicula por Id
        Task<bool> MovieExistByNameAsync(string name); //Me dice si existe una pelicula por nombre
        Task<bool> CrateMovieAsync(Movie movie); //Me crea una pelicula
        Task<bool> UpdateMovieAsync(Movie movie); //Me actualiza los datos de una pelicula creada
        Task<bool> DeleteMovieAsync(int id); //Me elimina una pelicula creada por Id
    }
}
