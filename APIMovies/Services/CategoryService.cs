using APIMovies.DAL.Models;
using APIMovies.DAL.Models.Dtos;
using APIMovies.Repository.IRepository;
using APIMovies.Services.IServices;
using AutoMapper;

namespace APIMovies.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mappper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository; 
            _mappper = mapper;
        }
        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); //Solo estoy llamando el metodo desde la capa Repository 

            return _mappper.Map<ICollection<CategoryDto>>(categories); //Mapeo la lista de categorias a una lissta de categorias DTO

        }
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id); //Solo estoy llamando el metodo desde la capa Repository 

            if (category == null)
            {
                throw new InvalidOperationException($"No se encontro la categoria con ID: '{id}'");
            }

            return _mappper.Map<CategoryDto>(category); //Mapeo la lista de categorias a una lissta de categorias DTO

        }
        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
        {
            //Validar si la categoria ya existe
            var categoryExists = await _categoryRepository.CategoryExistByNameAsync(categoryCreateDto.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{categoryCreateDto.Name}'");
            }
            //Mapear el DTO a la entidad
            var category = _mappper.Map<Category>(categoryCreateDto);

            //Crear la categoria en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Ocurrio un error al crear la categoria");
            }
            //Mapear la entidad creada a DTO
            return _mappper.Map<CategoryDto>(category);  
        }
        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto categoryUpdateDto, int id)
        {
            //Validar si la categoria ya existe
            var categoryExists = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontro la categoria con ID: '{id}'");
            }

            var nameExists = await _categoryRepository.CategoryExistByNameAsync(categoryUpdateDto.Name);

            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{categoryUpdateDto.Name}'");
            }

            //Mapear el DTO a la entidad
            _mappper.Map(categoryUpdateDto, categoryExists);

            //Actualizamos la categoria en el repositorio
            var categoryUpdate = await _categoryRepository.UpdateCategoryAsync(categoryExists);
            if (!categoryUpdate)
            {
                throw new Exception("Ocurrio un error al actualizar la categoria");
            }
            //Retornar el DTO actualizzado
            return _mappper.Map<CategoryDto>(categoryExists);
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            //Verificar si la categoría existe
            var categoryExists = await _categoryRepository.GetCategoryByIdAsync(id);

            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontro la categoria con ID: '{id}'");
            }

            //Eliminar la categoria del repositorio
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);

            if (!categoryDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la categoria");
            }
            return categoryDeleted;
        }
    }
}
