using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoxinhaSystem.Domain.Models
{
    public class Product : EntityBase
    {
        //[Key]
        //public int Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]        
        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public double IncQty { get; set; }

        [Column(TypeName = "VARCHAR(200)")]        
        public string Description { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public Unit Unit { get; set; }
    }

    public enum ProductType
    {
        Cake = 1,
        Frie = 2,
        Roast = 3,
        Sweet = 4
    }

    public enum Unit
    {
        UN = 1,
        KG = 2
    }
}