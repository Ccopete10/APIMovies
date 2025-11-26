using System.ComponentModel.DataAnnotations;

namespace APIMovies.DAL.Models
{
    public class AuditBase
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
