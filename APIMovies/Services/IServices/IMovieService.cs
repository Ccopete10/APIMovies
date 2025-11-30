using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;

namespace APIMovies.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync(); //Retorna una lista de peliculas
        Task<MovieDto> GetMovieByIdAsync(int id); //Retorna una pelicula por Id
        Task<bool> MovieExistByIdAsync(int id); //Me dice si existe una pelicula por Id
        Task<bool> MovieExistByNameAsync(string name); //Me dice si existe una pelicula por nombre
        Task<MovieDto> CrateMovieAsync(MovieCreateUpdateDto movieCreateDto); //Me crea una pelicula
        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieUpdateDto, int id); //Me actualiza los datos de una pelicula creada
        Task<bool> DeleteMovieAsync(int id); //Me elimina una pelicula creada por Id
    }
}
