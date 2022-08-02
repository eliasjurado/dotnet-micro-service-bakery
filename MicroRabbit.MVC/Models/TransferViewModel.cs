using System.ComponentModel.DataAnnotations;

namespace MicroRabbit.MVC.Models
{
    public class TransferViewModel
    {
        public string TransferNotes { get; set; }
        [Required]
        public int FromAccount { get; set; }
        [Required]
        public int ToAccount { get; set; }
        [Required]
        public decimal TransferAmount { get; set; }
    }
}
