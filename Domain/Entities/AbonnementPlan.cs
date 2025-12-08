using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class AbonnementPlan
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public decimal PrixMensuel { get; set; }

        public ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();
    }
}