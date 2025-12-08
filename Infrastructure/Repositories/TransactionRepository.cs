using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;

namespace TP3Genie2.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public Transaction? GetById(int id)
        {
            return _context.Transactions.Find(id);
        }

        public List<Transaction> GetByMembre(int membreId)
        {
            return _context.Transactions
                .Where(t => t.Compte.MembreId == membreId)
                .ToList();
        }

        public void Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}
