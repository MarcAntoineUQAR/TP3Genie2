using System;
using System.Collections.Generic;
using System.Linq;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // ===========================
            // UTILISATEURS
            // ===========================
            if (!context.Utilisateurs.Any())
            {
                var admin = new Utilisateur
                {
                    Username = "admin",
                    Password = "admin123*",
                    Role = UserRole.Administrateur
                };

                var membreUser = new Utilisateur
                {
                    Username = "jean",
                    Password = "jean123*",
                    Role = UserRole.Membre
                };

                context.Utilisateurs.AddRange(admin, membreUser);
                context.SaveChanges();
            }

            // ===========================
            // MEMBRE PRINCIPAL
            // ===========================
            if (!context.Membres.Any())
            {
                var membreUser = context.Utilisateurs.First(u => u.Username == "jean");

                var membre = new Membre
                {
                    Prenom = "Jean",
                    Nom = "Laronde",
                    Email = "jean.laronde@google.com",
                    Adresse = "123 Rue Jean",
                    Telephone = "418-123-4567",
                    UtilisateurId = membreUser.Id,
                    Compte = new Compte
                    {
                        Solde = 50.00m
                    }
                };

                context.Membres.Add(membre);
                context.SaveChanges();
            }

            var membrePrincipal = context.Membres.First();

            // ===========================
            // PLANS D’ABONNEMENT
            // ===========================
            if (!context.AbonnementPlans.Any())
            {
                context.AbonnementPlans.AddRange(
                    new AbonnementPlan { Nom = "Standard", PrixMensuel = 9.99m },
                    new AbonnementPlan { Nom = "Premium", PrixMensuel = 14.99m }
                );
                context.SaveChanges();
            }

            // ===========================
            // ABONNEMENT PRINCIPAL
            // ===========================
            if (!context.Abonnements.Any())
            {
                var basicPlan = context.AbonnementPlans.First(p => p.Nom == "Standard");

                context.Abonnements.Add(new Abonnement
                {
                    DateDebut = DateTime.Today.AddDays(-10),
                    DateFin = null,
                    RenouvellementAuto = true,
                    MembreId = membrePrincipal.Id,
                    PlanId = basicPlan.Id
                });

                context.SaveChanges();
            }

            // ===========================
            // CATÉGORIES
            // ===========================
            if (!context.Categories.Any())
            {
                var cats = new[]
                {
                    "Action","Aventure","Science-fiction","Fantastique","Comédie","Drame",
                    "Horreur","Thriller","Animation","Documentaire","Romance","Crime",
                    "Guerre","Historique","Musical","Mystère","Super-héros","Western",
                    "Biographie","Familial","Sport","Noir","Policier","Fantasy urbaine"
                };

                foreach (var name in cats)
                    context.Categories.Add(new Categorie { Nom = name });

                context.SaveChanges();
            }

            var cat = context.Categories.ToDictionary(c => c.Nom, c => c);

            // ===========================
            // FILMS
            // ===========================
            List<Film> seededFilms = new List<Film>();

            if (!context.Films.Any())
            {
                seededFilms = new List<Film>
                {
                    new Film { Titre = "The Matrix", AnneeSortie = 1999, Duree = 136,
                        Synopsis = "Un pirate informatique découvre la vérité sur la Matrice.",
                        Prix = 12.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "matrix.jpg", BandeAnnoncePath = "matrix_trailer.mp4",
                        CategorieId = cat["Science-fiction"].Id },

                    new Film { Titre = "Interstellar", AnneeSortie = 2014, Duree = 169,
                        Synopsis = "Une équipe d'explorateurs voyage à travers un trou de ver.",
                        Prix = 15.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "interstellar.jpg", BandeAnnoncePath = "interstellar_trailer.mp4",
                        CategorieId = cat["Science-fiction"].Id },

                    new Film { Titre = "Inception", AnneeSortie = 2010, Duree = 148,
                        Synopsis = "Un voleur infiltre les rêves pour implanter une idée.",
                        Prix = 14.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "inception.jpg", BandeAnnoncePath = "inception_trailer.mp4",
                        CategorieId = cat["Action"].Id },

                    new Film { Titre = "Mad Max: Fury Road", AnneeSortie = 2015, Duree = 120,
                        Synopsis = "Dans un désert post-apocalyptique...",
                        Prix = 13.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "madmax.jpg", BandeAnnoncePath = "madmax_trailer.mp4",
                        CategorieId = cat["Action"].Id },

                    new Film { Titre = "The Godfather", AnneeSortie = 1972, Duree = 175,
                        Synopsis = "Le patriarche d'une famille mafieuse...",
                        Prix = 11.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "godfather.jpg", BandeAnnoncePath = "godfather_trailer.mp4",
                        CategorieId = cat["Crime"].Id },

                    new Film { Titre = "Parasite", AnneeSortie = 2019, Duree = 132,
                        Synopsis = "Une famille pauvre s'infiltre...",
                        Prix = 13.49m, Statut = FilmStatus.Disponible,
                        AffichePath = "parasite.jpg", BandeAnnoncePath = "parasite_trailer.mp4",
                        CategorieId = cat["Drame"].Id },

                    new Film { Titre = "The Shining", AnneeSortie = 1980, Duree = 146,
                        Synopsis = "Un gardien sombre dans la folie.",
                        Prix = 10.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "shining.jpg", BandeAnnoncePath = "shining_trailer.mp4",
                        CategorieId = cat["Horreur"].Id },

                    new Film { Titre = "Se7en", AnneeSortie = 1995, Duree = 127,
                        Synopsis = "Deux détectives traquent un tueur.",
                        Prix = 11.49m, Statut = FilmStatus.Disponible,
                        AffichePath = "se7en.jpg", BandeAnnoncePath = "se7en_trailer.mp4",
                        CategorieId = cat["Thriller"].Id },

                    new Film { Titre = "Toy Story", AnneeSortie = 1995, Duree = 81,
                        Synopsis = "Les jouets prennent vie.",
                        Prix = 9.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "toystory.jpg", BandeAnnoncePath = "toystory_trailer.mp4",
                        CategorieId = cat["Animation"].Id },

                    new Film { Titre = "Le Roi Lion", AnneeSortie = 1994, Duree = 88,
                        Synopsis = "Le destin d'un jeune lion.",
                        Prix = 9.99m, Statut = FilmStatus.Disponible,
                        AffichePath = "lionking.jpg", BandeAnnoncePath = "lionking_trailer.mp4",
                        CategorieId = cat["Familial"].Id },

                    new Film { Titre = "Titanic", AnneeSortie = 1997, Duree = 195,
                        Synopsis = "Une romance tragique.",
                        Prix = 12.49m, Statut = FilmStatus.Disponible,
                        AffichePath = "titanic.jpg", BandeAnnoncePath = "titanic_trailer.mp4",
                        CategorieId = cat["Romance"].Id }
                };

                context.Films.AddRange(seededFilms);
                context.SaveChanges();
            }
            else
            {
                seededFilms = context.Films.ToList();
            }

            // SAFELY retrieve Matrix & Inception *from the list*, not by title
            var filmMatrix = seededFilms.FirstOrDefault(f => f.Titre.Contains("Matrix"));
            var filmInception = seededFilms.FirstOrDefault(f => f.Titre.Contains("Inception"));

            // If the user renamed or deleted them, skip dependent seed data
            if (filmMatrix == null || filmInception == null)
                return;

            // ===========================
            // CARTE DE CRÉDIT
            // ===========================
            if (!context.CartesCredits.Any())
            {
                var compte = context.Comptes.First(c => c.MembreId == membrePrincipal.Id);

                context.CartesCredits.Add(new CarteCredit
                {
                    Numero = "4111111111111111",
                    Titulaire = $"{membrePrincipal.Prenom} {membrePrincipal.Nom}",
                    Expiration = DateTime.Today.AddYears(2),
                    CompteId = compte.Id
                });

                context.SaveChanges();
            }

            // ===========================
            // TRANSACTIONS
            // ===========================
            if (!context.Transactions.Any())
            {
                var compte = context.Comptes.First(c => c.MembreId == membrePrincipal.Id);

                var t1 = new Transaction
                {
                    Date = DateTime.Today.AddDays(-7),
                    Montant = -9.99m,
                    Type = TransactionType.Abonnement,
                    CompteId = compte.Id
                };

                var t2 = new Transaction
                {
                    Date = DateTime.Today.AddDays(-2),
                    Montant = -filmMatrix.Prix,
                    Type = TransactionType.PaiementFilm,
                    CompteId = compte.Id
                };

                compte.Solde += t1.Montant + t2.Montant;

                context.Transactions.AddRange(t1, t2);
                context.Comptes.Update(compte);
                context.SaveChanges();
            }

            // ===========================
            // VISIONNEMENTS
            // ===========================
            if (!context.Visionnements.Any())
            {
                context.Visionnements.AddRange(
                    new Visionnement
                    {
                        Date = DateTime.Today.AddDays(-2),
                        ModeAcces = ModeAcces.Abonnement,
                        FilmId = filmMatrix.Id,
                        MembreId = membrePrincipal.Id
                    },
                    new Visionnement
                    {
                        Date = DateTime.Today.AddDays(-1),
                        ModeAcces = ModeAcces.A_L_Unite,
                        FilmId = filmInception.Id,
                        MembreId = membrePrincipal.Id
                    }
                );

                context.SaveChanges();
            }

            // ===========================
            // COTES
            // ===========================
            if (!context.Cotes.Any())
            {
                context.Cotes.AddRange(
                    new Cote
                    {
                        Valeur = 5,
                        Commentaire = "Film culte, excellent.",
                        FilmId = filmMatrix.Id,
                        MembreId = membrePrincipal.Id
                    },
                    new Cote
                    {
                        Valeur = 4,
                        Commentaire = "Très bon mais complexe.",
                        FilmId = filmInception.Id,
                        MembreId = membrePrincipal.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
