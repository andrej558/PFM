using CsvHelper.Configuration;
using WebApplication2.Models;

namespace WebApplication2.Services.Csv_Maps
{
    public class MmcMaps : ClassMap<MccCSV>
    {

        public MmcMaps() {

            AutoMap(System.Globalization.CultureInfo.InvariantCulture);
            Map(m=>m.code).Name("Code");
            Map(m => m.merchanttype).Name("MerchantType");

        }
    }
}
