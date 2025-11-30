using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;
using APIMovies.Repository.IRepository;
using APIMovies.Services.IServices;
using AutoMapper;

namespace APIMovies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }
        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var movies = await _movieRepository.GetMovieByIdAsync(id);
            if (movies == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: '{id}'");
            }
            return _mapper.Map<MovieDto>(movies);
        }
        public async Task<bool> MovieExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> MovieExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<MovieDto> CrateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            //Validar si la pelicula ya existe
            var movieExist = await _movieRepository.MovieExistByNameAsync(movieCreateDto.Name);
            if (movieExist)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de '{movieCreateDto.Name}'");
            }
            //Mapear el Dto a la entidad
            var movie = _mapper.Map<Movie>(movieCreateDto);

            //Crear la pelicula en el repositorio
            var movieCreated = await _movieRepository.CrateMovieAsync(movie);
            if (!movieCreated)
            {
                throw new Exception("Ocurrio un error al crear la pelicula");
            }
            return _mapper.Map<MovieDto>(movie);
        }
        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto movieUpdateDto, int id)
        {
            //Validar si la pelicula existe
            var movieExists = await _movieRepository.GetMovieByIdAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: '{id}'");
            }

            var nameExists = await _movieRepository.MovieExistByNameAsync(movieUpdateDto.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de '{movieUpdateDto.Name}'");
            }
            //Mapear el Dto a la entidad
            _mapper.Map(movieUpdateDto, movieExists);

            //Actualizar la pelicula en el repositorio
            var movieUpdate = await _movieRepository.UpdateMovieAsync(movieExists);
            if (!movieUpdate)
            {
                throw new Exception("Ocurrio un error al actualizar la pelicula");
            }
            //Retornar el Dto Actualizado
            return _mapper.Map<MovieDto>(movieExists);
        }
        public async Task<bool> DeleteMovieAsync(int id)
        {
            //Validar si la pelicula existe
            var movieExists = await _movieRepository.GetMovieByIdAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: '{id}'");
            }

            //Eliminar la pelicula del repositorio
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (!movieDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la pelicula");
            }
            return movieDeleted;
        }   
    }
}
