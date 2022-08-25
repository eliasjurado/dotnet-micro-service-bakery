using System;
using System.Collections.Generic;

namespace Mango.Services.OrderAPI.Models
{
    public class SellHeader
    {
        public int IdSellHeader { get; set; }
        public string UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public DateTime SellTime { get; set; }
        
        public List<OrderDetails> SellDetails { get; set; }
        
    }


}
