using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public TypePersonne TypePersonne { get; set; }

        public ICollection<FilmCredit> FilmCredits { get; set; } = new List<FilmCredit>();
    }
}