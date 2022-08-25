using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.OrderAPI.Models
{
    public class SellHeader
    {
        [Key]
        public int IdSellHeader { get; set; }
        public string UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public DateTime SellTime { get; set; }
        
        public List<SellDetails> SellDetails { get; set; }
        
    }


}
