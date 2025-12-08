using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms.Controllers
{
    public class TransactionController
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        public Transaction? GetById(int id)
        {
            return _service.GetById(id);
        }

        public List<Transaction> GetByMembre(int membreId)
        {
            return _service.GetByMembre(membreId);
        }

        public void Add(Transaction transaction)
        {
            _service.Add(transaction);
        }
    }
}
