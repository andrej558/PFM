using WebApplication2.Database.Entities;
using WebApplication2.Models;

namespace WebApplication2.Database.Repositories
{
    public interface ITransactionRepository
    {
        public PageSortedList<Transaction> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.asc);

        public TransactionEntity GetTransaction(string id);

        public TransactionEntity Update(TransactionEntity transaction);

        public SplitTransactionEntity Split(SplitTransactionEntity splitTransaction);

    }
}
