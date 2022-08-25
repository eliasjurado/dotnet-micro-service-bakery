using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.OrderAPI.Models
{
    public class SellDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int IdSellHeader { get; set; }
        
        [ForeignKey("IdSellHeader")]
        public virtual SellHeader SellHeader{ get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }        
        public double Price { get; set; }
    }
}
