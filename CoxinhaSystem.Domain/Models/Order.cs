using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoxinhaSystem.Domain.Models
{
    public class Order : EntityBase
    {
        //[Key]
        //public int Id { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required]
        public DateTime DtCreation { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public bool Paid { get; set; }
        
        [Required]
        public double Total { get; set; }

        [Required]
        public double Discount { get; set; }

        [Required]
        public double TotalWithDiscount { get; set; }

        public DateTime DeliveryDate { get; set; }

        [Column(TypeName = "VARCHAR(200)")]        
        public string Description { get; set; }
        
        public virtual Customer Customer { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }
    }

    public enum Status
    {
        Created = 10,
        InProgress = 20,
        Finished = 30,
        Canceled = 40
    }
}