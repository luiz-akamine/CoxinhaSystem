using System.ComponentModel.DataAnnotations;

namespace CoxinhaSystem.Domain.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
