using System;
using System.ComponentModel.DataAnnotations;

namespace CoxinhaSystem.Domain.Models
{
    public class EntityBase : IDisposable
    {
        [Key]
        public int Id { get; set; }

        public void Dispose()
        {
            
        }
    }
}
