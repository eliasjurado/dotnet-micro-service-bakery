using System;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ProductAPI.Models
{
    public class ProcessProduct
    {
        [Key]
        public int Id { get; set; }
        
        public int ProductId { get; set; }   
                
        public double Stock { get; set; }       

        public DateTime ExpirationDate { get; set; }
        public DateTime ProductionDate { get; set; }
        
    }
}
