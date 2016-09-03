using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoxinhaSystem.Domain.Models
{
    public class Address : EntityBase
    {        
        [Required]
        public int CEP { get; set; }

        [Column(TypeName = "VARCHAR(300)")]
        [Required]
        public string AddressName { get; set; }
        
        public int Number { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string District { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Complement { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string City { get; set; }

        [Column(TypeName = "VARCHAR(5)")]
        public string State { get; set; }

        [Required]
        public bool MainAddress { get; set; }

        public virtual Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
