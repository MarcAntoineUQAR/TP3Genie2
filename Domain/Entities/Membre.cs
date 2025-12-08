using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class Membre
    {
        public int Id { get; set; }
        public string Prenom { get; set; } = null!;
        public string Nom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Adresse { get; set; } = null!;
        public string Telephone { get; set; } = null!;

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        public Abonnement? Abonnement { get; set; }
        public Compte Compte { get; set; } = null!;
        public ICollection<Visionnement> Visionnements { get; set; } = new List<Visionnement>();
        public ICollection<Cote> Cotes { get; set; } = new List<Cote>();
    }
}