using APIMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMovies.DAL
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        //Sección para crear el dbset de las entidades o modelos
        public DbSet<Category> Categories { get; set; }
    }
}
