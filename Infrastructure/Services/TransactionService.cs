using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;

        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public Transaction? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Transaction> GetByMembre(int membreId)
        {
            return _repo.GetByMembre(membreId);
        }

        public void Add(Transaction transaction)
        {
            _repo.Add(transaction);
        }
    }
}
