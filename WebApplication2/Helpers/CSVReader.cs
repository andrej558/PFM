using CsvHelper;
using WebApplication2.Models;

namespace WebApplication2.Helpers
{
    public class CSVReader
    {

        private static readonly string MMCPath = "C:\\Users\\InternMK-10\\bankapp\\WebApplication2\\WebApplication2\\Content\\mmc_codes.csv";
        private readonly string CategoryPath = "C:\\Users\\InternMK-10\\bankapp\\WebApplication2\\WebApplication2\\Content\\categories.csv";

        private readonly string TransactionsPath = "C:\\Users\\InternMK-10\\bankapp\\WebApplication2\\WebApplication2\\Content\\transactions.csv";


        public List<dynamic> GetData(string path) {
            using (var reader = new StreamReader(path))
            {
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {

                    return csv.GetRecords<dynamic>().ToList();

                }
            }



        }

        public List<MccCSV> GetMMCCodes()
        {
            using (var reader = new StreamReader(MMCPath))
            {
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {

                    return csv.GetRecords<MccCSV>().ToList();

                }
            }
        }

        public List<TransactionCSV> GetTransactionCSVs() {

            using (var reader = new StreamReader(TransactionsPath))
            {
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {

                    return csv.GetRecords<TransactionCSV>().ToList();

                }
            }

        }



        


    }
}
