using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Database.Entities
{
    public class SplitTransactionEntity
    {
        [Key]
        [Required]

        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }


        [ForeignKey("CatCode")]
        public string CategoryCode { get; set; }
        public virtual CategoryEntity Category { get; set; }

        [ForeignKey("TransactionID")]
        public string TransactionId { get; set; }
        public virtual TransactionEntity Transaction { get; set; }
    }
}
