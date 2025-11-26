using APIMovies.DAL.Models;

namespace APIMovies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Me retorna una lista de categorias
        Task<Category> GetCategoryByIdAsync(int id); //Me retorna una categoria por ID
        Task<bool> CategoryExistByIdAsync(int id); //Me dice si existe una categoria por ID
        Task<bool> CategoryExistByNameAsync(string name);//Me dice si existe una categoria por nombre
        Task<bool> CreateCategoryAsync(Category category); //Me crea una categoria
        Task<bool> UpdateCategoryAsync(Category category); //Me crea una categoria --puedo actualizar el nombre y la fecha de actualizacion
        Task<bool> DeleteCategoryAsync(int id); //Me elimina una categoria
    }
}
