using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
	public class Abonnement
	{
		public int Id { get; set; }
		public DateTime DateDebut { get; set; }
		public DateTime? DateFin { get; set; }
		public bool RenouvellementAuto { get; set; }

		public int? MembreId { get; set; }
		public Membre? Membre { get; set; }

		public int PlanId { get; set; }
		public AbonnementPlan Plan { get; set; } = null!;
	}
}