using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class FilmCredit
    {
        public int Id { get; set; }
        public TypeRole Role { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;

        public int PersonneId { get; set; }
        public Personne Personne { get; set; } = null!;
    }
}