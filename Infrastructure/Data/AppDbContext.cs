using TP3Genie2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TP3Genie2.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<AbonnementPlan> AbonnementPlans { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<CarteCredit> CartesCredits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<FilmCredit> FilmCredits { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<PisteAudio> PistesAudio { get; set; }
        public DbSet<PisteSousTitre> PistesSousTitre { get; set; }
        public DbSet<Visionnement> Visionnements { get; set; }
        public DbSet<Cote> Cotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relation utilisateur-membre (1-1)
            modelBuilder.Entity<Utilisateur>()
                .HasOne(u => u.Membre)
                .WithOne(m => m.Utilisateur)
                .HasForeignKey<Membre>(m => m.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation membre-abonnement (1-1)
            modelBuilder.Entity<Membre>()
                .HasOne(m => m.Abonnement)
                .WithOne(a => a.Membre)
                .HasForeignKey<Abonnement>(a => a.MembreId)
                .IsRequired(false);

            // Relation membre-compte (1-1)
            modelBuilder.Entity<Membre>()
                .HasOne(m => m.Compte)
                .WithOne(c => c.Membre)
                .HasForeignKey<Compte>(c => c.MembreId);

            // Relation compte-transactions (1-*)
            modelBuilder.Entity<Compte>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Compte)
                .HasForeignKey(t => t.CompteId);

            // Relation compte-cartes crédit (1-*)
            modelBuilder.Entity<Compte>()
                .HasMany(c => c.CartesCredits)
                .WithOne(cc => cc.Compte)
                .HasForeignKey(cc => cc.CompteId);

            // Relation abonnements-plan (*-1)
            modelBuilder.Entity<Abonnement>()
                .HasOne(a => a.Plan)
                .WithMany(p => p.Abonnements)
                .HasForeignKey(a => a.PlanId);

            // Relation film-catégorie (*-1)
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Categorie)
                .WithMany(c => c.Films)
                .HasForeignKey(f => f.CategorieId);

            // Relation film-filmcredit (1-*)
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Credits)
                .WithOne(fc => fc.Film)
                .HasForeignKey(fc => fc.FilmId);

            // Relation personne-filmcredit (1-*)
            modelBuilder.Entity<Personne>()
                .HasMany(p => p.FilmCredits)
                .WithOne(fc => fc.Personne)
                .HasForeignKey(fc => fc.PersonneId);

            // Relation film-pistes audio (1-*)
            modelBuilder.Entity<Film>()
                .HasMany(f => f.PistesAudio)
                .WithMany(pa => pa.Films);

            // Relation film-pistes sous-titre (1-*)
            modelBuilder.Entity<Film>()
                .HasMany(f => f.SousTitres)
                .WithMany(ps => ps.Films);

            // Relation film-visionnements (1-*)
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Visionnements)
                .WithOne(v => v.Film)
                .HasForeignKey(v => v.FilmId);

            // Relation membre-visionnements (1-*)
            modelBuilder.Entity<Membre>()
                .HasMany(m => m.Visionnements)
                .WithOne(v => v.Membre)
                .HasForeignKey(v => v.MembreId);

            // Relation membre-cotes (1-*)
            modelBuilder.Entity<Membre>()
                .HasMany(m => m.Cotes)
                .WithOne(c => c.Membre)
                .HasForeignKey(c => c.MembreId);

            // Relation film-cotes (1-*)
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Cotes)
                .WithOne(c => c.Film)
                .HasForeignKey(c => c.FilmId);
        }
    }
}