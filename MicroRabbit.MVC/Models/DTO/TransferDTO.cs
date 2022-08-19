﻿namespace MicroRabbit.MVC.Models.Dto
{
    public class TransferDto
    {
        public int Id { get; set; }
        public int ProductionAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IdProduct { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
