using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public int AnneeSortie { get; set; }
        public int Duree { get; set; }
        public string Synopsis { get; set; } = null!;
        public decimal Prix { get; set; }
        public FilmStatus Statut { get; set; }
        public string? AffichePath { get; set; }
        public string? BandeAnnoncePath { get; set; }

        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; } = null!;

        public ICollection<FilmCredit> Credits { get; set; } = new List<FilmCredit>();
        public ICollection<Visionnement> Visionnements { get; set; } = new List<Visionnement>();
        public ICollection<PisteSousTitre> SousTitres { get; set; } = new List<PisteSousTitre>();
        public ICollection<PisteAudio> PistesAudio { get; set; } = new List<PisteAudio>();
        public ICollection<Cote> Cotes { get; set; } = new List<Cote>();
        public string MotsClés { get; set; } = "";
    }
}