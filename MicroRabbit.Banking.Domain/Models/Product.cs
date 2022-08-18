namespace MicroRabbit.Banking.Domain.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public int Stock { set; get; }

        public decimal Cost { set; get; }

        public DateTime Creation_Date { set; get; }
    }

   
}
