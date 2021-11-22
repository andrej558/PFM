using WebApplication2.Database.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface ITransactionService
    {
        public PageSortedList<Transaction> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.asc);

        public TransactionEntity Categorize(string id, string catcode);

        public TransactionEntity Split(string id, List<SingleCategorySplit> Splits);
    }
}
