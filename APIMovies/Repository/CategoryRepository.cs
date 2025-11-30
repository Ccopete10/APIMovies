using APIMovies.DAL;
using APIMovies.DAL.Models;
using APIMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIMovies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;      
        }
        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var categories = await _context.Categories
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();
            return categories;
        }
        public async Task<Category> GetCategoryByIdAsync(int id) //async y el await
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id); //lambda expressions  
        }
        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(x => x.Id == id);
        }
        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(x => x.Name == name);
        }
        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreateDate = DateTime.UtcNow;

            await _context.Categories.AddAsync(category);
            return await SaveAsync();
            //SQL INSERT    
        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;
            _context.Categories.Update(category);
            return await SaveAsync();
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryByIdAsync(id); //primero consulta que si exista la categoria

            if (category == null)
            {
                return false; //la categoria no existe
            }
            _context.Categories.Remove(category);
            return await SaveAsync();
            //sql Delete from Categories where Id = id
        }
        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
