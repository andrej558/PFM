using WebApplication2.Database.Entities;
using WebApplication2.Database.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class TransactionService : ITransactionService
    {
        //private readonly string TransactionPath = "C:\\Users\\InternMK-10\\bankapp\\WebApplication2\\WebApplication2\\Content\\transactions.csv";

        private ITransactionRepository transactionRepository;
        private ICategoryService categoryService;

        public TransactionService(ITransactionRepository transactionRepository, ICategoryService categoryService)
        {
            this.transactionRepository = transactionRepository;
            this.categoryService = categoryService;
        }

        public TransactionEntity Categorize(string id, string catcode)
        {

            var transaction = transactionRepository.GetTransaction(id);

            var category = categoryService.GetCategory(catcode);

            if (transaction == null || category == null) {
                return null;
            }


            transaction.CategoryCode = catcode;
            transaction.Category = category;

            transactionRepository.Update(transaction);

            return transaction;

        }

        public PageSortedList<Transaction> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.asc) { 
            

            var result = transactionRepository.GetTransactions(page, pageSize, sortBy, sortOrder);

            return result;


        }

        public TransactionEntity Split(string id, List<SingleCategorySplit> Splits)
        {

            var transaction = transactionRepository.GetTransaction(id);

            if (transaction == null) return null;

            double totalAmount = transaction.Amount;


            foreach (var split in Splits) {

                var category = categoryService.GetCategory(split.catcode);

                if (category == null) continue;

                SplitTransactionEntity splitTransaction = new SplitTransactionEntity();

                if (totalAmount > 0 && split.amount < totalAmount)
                {
                    splitTransaction.Amount = split.amount;
                }
                else {
                    return null;
                }

                splitTransaction.CategoryCode = split.catcode;
                splitTransaction.Category = category;

                splitTransaction.TransactionId = transaction.Id;
                splitTransaction.Transaction = transaction;

                totalAmount -= split.amount;

                var result = transactionRepository.Split(splitTransaction);

            }

            return transaction;

        }
    }
}
