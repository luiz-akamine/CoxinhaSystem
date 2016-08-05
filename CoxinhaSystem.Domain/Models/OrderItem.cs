using System.ComponentModel.DataAnnotations;

namespace CoxinhaSystem.Domain.Models
{
    public class OrderItem : EntityBase
    {
        //[Key]
        //public int Id { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public double Qty { get; set; }

        [Required]
        public double Price { get; set; }
    }
}