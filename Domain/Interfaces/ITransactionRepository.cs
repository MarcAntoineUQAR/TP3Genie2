using TP3Genie2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Genie2.Domain.Interfaces
{
	public interface ITransactionRepository
	{
		Transaction? GetById(int id);
		List<Transaction> GetByMembre(int membreId);
		void Add(Transaction transaction);
	}
}