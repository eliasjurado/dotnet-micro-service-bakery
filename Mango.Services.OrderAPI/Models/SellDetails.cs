﻿using System.ComponentModel.DataAnnotations;

namespace Mango.Services.OrderAPI.Models
{
    public class SellDetails
    {
        [Key]
        public int Id { get; set; }

        public int IdSellHeader { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }

        public int SellHeaderIdSellHeader { get; set; }
    }
}