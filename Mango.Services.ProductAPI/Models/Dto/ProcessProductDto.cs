using System;

namespace Mango.Services.ProductAPI.Models.Dtos
{
    public class ProcessProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public double Stock { get; set; }

        public DateTime ExpirationDate { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}