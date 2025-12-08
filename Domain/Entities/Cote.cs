using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class Cote
    {
        public int Id { get; set; }
        public int Valeur { get; set; }
        public string Commentaire { get; set; } = null!;

        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;

        public int MembreId { get; set; }
        public Membre Membre { get; set; } = null!;
    }
}