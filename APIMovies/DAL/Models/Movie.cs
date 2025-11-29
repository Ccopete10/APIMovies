using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required] //Este data annotation indica que el campo es obligatorio
        [Display(Name = "Nombre de la pelicula")] //Me sirve para personalizaar el nombre que se muestra en las vistas o mensajes de error
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Clasification { get; set; }
    }
}
