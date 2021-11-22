namespace WebApplication2.Models
{
    public class TransactionCSV
    {
        public string id { get; set; }
        public string beneficiaryname { get; set; }
        public string date { get; set; }
        public string direction { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public string mcc { get; set; }
        public string kind { get; set; }
    }
}
