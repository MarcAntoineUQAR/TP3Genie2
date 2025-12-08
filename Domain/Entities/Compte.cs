using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class Compte
    {
        public int Id { get; set; }
        public decimal Solde { get; set; }

        public int MembreId { get; set; }
        public Membre Membre { get; set; } = null!;

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<CarteCredit> CartesCredits { get; set; } = new List<CarteCredit>();
    }
}