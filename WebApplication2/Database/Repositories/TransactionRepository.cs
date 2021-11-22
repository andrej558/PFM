using System.Linq;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Database.Entities;

namespace WebApplication2.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {

        private AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public Entities.TransactionEntity GetTransaction(string id)
        {

            return _context.Transactions.Find(id);
        }

        public PageSortedList<Transaction> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.asc)
        {

            var query = _context.Transactions.AsQueryable();

            var total = query.Count();

            var totalPages = total = (int)Math.Ceiling(total * 1.0 / pageSize);


            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortOrder == SortOrder.desc)
                {
                    query = query.OrderByDescending(p=>p.Id);
                   
                }
                else
                {
                    query = query.OrderBy(p => p.Id);
                  
                    sortOrder = SortOrder.asc;
                }
            }
            else
            {
                query = query.OrderBy(p => p.Id);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = query.ToList();


            List<Transaction> transactions = new List<Transaction>();

            foreach (var item in items)
            {
                Transaction transaction = new Transaction();

                transaction.Id = item.Id;
                transaction.BeneficiaryName = item.BeneficiaryName;
                transaction.Date = item.Date;
                transaction.Direction = item.Direction;
                transaction.Amount = item.Amount;
                transaction.Description = item.Description;
                transaction.Currency = item.Currency;

                if (item.Mcc != null) {
                    transaction.Mcc = item.Mcc.Code;
                }
                //transaction.m
                transaction.Kind = item.Kind;

                transactions.Add(transaction);
            }


            return new PageSortedList<Transaction>
            {
                Page = page,
                PageSize = pageSize,
                SortBy = sortBy,
                SortOrder = sortOrder,
                TotalCount = total,
                TotalPages = totalPages == 0 ? 1 : totalPages,
                Items = transactions
            };
        }

        public SplitTransactionEntity Split(SplitTransactionEntity splitTransaction)
        {
            _context.Splits.Add(splitTransaction);
            _context.SaveChanges();

            return splitTransaction;
        }

        public TransactionEntity Update(TransactionEntity transaction)
        {
            _context.Update(transaction);

            _context.SaveChanges();

            return transaction;
        }
    }
    }
