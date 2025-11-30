using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models.Dtos
{
    public class MovieDto
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100")]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        public string? Description { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres es de 10")]
        public string Clasification { get; set; }
        public DateTime createDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
