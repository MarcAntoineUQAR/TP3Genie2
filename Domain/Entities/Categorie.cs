using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;

        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}