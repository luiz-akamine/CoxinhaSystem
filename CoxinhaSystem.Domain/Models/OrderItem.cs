using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoxinhaSystem.Domain.Models
{
    public class OrderItem : EntityBase
    {
        public virtual Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public double Qty { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual Order Order { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}