using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoxinhaSystem.Domain.Models
{
    public class Phone : EntityBase
    {
        //[Key]
        //public int Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]        
        [Required]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Description { get; set; }

        public virtual Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}