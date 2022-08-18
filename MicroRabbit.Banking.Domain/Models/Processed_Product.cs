namespace MicroRabbit.Banking.Domain.Models
{
    public class Processed_Product
    {
        public int Id { set; get; }

        public int Id_Product { set; get; }

        public int Amount { set; get; }

        public DateTime Production_Date { set; get; }
        public DateTime Expiration_Date { set; get; }
    }

   
}
