using WebApplication2.Models;

namespace WebApplication2.Commands
{
    public class SplitTransactionCommand
    {

        public List<SingleCategorySplit> Splits { get; set; }
    }
}
