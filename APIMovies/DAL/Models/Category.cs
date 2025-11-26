using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models
{
    public class Category: AuditBase
    {
        [Required] //Este data annotation indica que el campo es obligatorio
        [Display(Name="Nombre de la categoria")] //Me sirve para personalizaar el nombre que se muestra en las vistas o mensajes de error
        public string Name { get; set; }

    }
}
