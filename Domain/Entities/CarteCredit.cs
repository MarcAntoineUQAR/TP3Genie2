using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
	public class CarteCredit
	{
		public int Id { get; set; }
		public string Numero { get; set; } = null!;
		public string Titulaire { get; set; } = null!;
		public DateTime Expiration { get; set; }

		public int CompteId { get; set; }
		public Compte Compte { get; set; } = null!;
	}
}