namespace WebApplication2.Models
{
    public class Transaction
    {

        public string Id { get; set; }
        public string BeneficiaryName { get; set; }

        public string Date { get; set; }

        public TransactionDirection Direction { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }

        public int Mcc { get; set; }

        public TransactionKind Kind { get; set; }

       
    }
}
