using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoxinhaSystem.Domain.Models
{
    public class Customer : EntityBase
    {   
        //[Key]     
        //public int Id { get; set; }
        
        [Column(TypeName = "VARCHAR(100)")]                
        [Required]        
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(200)")]       
        [Required]
        public string FullAddress { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Description { get; set; }

        public virtual IList<Phone> Phones { get; set; }
    }
}