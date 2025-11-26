using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;

namespace APIMovies.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); //Me retorna una lista de categorias
        Task<CategoryDto> GetCategoryByIdAsync(int id); //Me retorna una categoria por ID
        Task<bool> CategoryExistByIdAsync(int id); //Me dice si existe una categoria por ID
        Task<bool> CategoryExistByNameAsync(string name);//Me dice si existe una categoria por nombre
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto); //Me crea una categoria
        Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto); //Me crea una categoria --puedo actualizar el nombre y la fecha de actualizacion
        Task<bool> DeleteCategoryAsync(int id); //Me elimina una categoria
    }
}
