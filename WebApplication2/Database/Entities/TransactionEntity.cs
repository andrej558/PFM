using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.Database.Entities
{
    public class TransactionEntity
    {

        [Key]
        public string Id { get; set; }

        public string? BeneficiaryName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public TransactionDirection Direction { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Currency { get; set; }


        [ForeignKey("MccCode")]
        public int? MccCode { get; set; }
        public virtual MccCodesEntity? Mcc { get; set; }

        [Required]
        public TransactionKind Kind { get; set; }


        [ForeignKey("CatCode")]
        public string? CategoryCode { get; set; }
        public virtual CategoryEntity? Category { get; set; }

        public virtual ICollection<SplitTransactionEntity> Splits { get; set; }
    }
}