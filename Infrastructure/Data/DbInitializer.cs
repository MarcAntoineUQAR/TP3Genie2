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

            // Utilisateurs
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

            // Membres + Comptes
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

            // Plans d’abonnement
            if (!context.AbonnementPlans.Any())
            {
                var basic = new AbonnementPlan
                {
                    Nom = "Standard",
                    PrixMensuel = 9.99m
                };

                var premium = new AbonnementPlan
                {
                    Nom = "Premium",
                    PrixMensuel = 14.99m
                };

                context.AbonnementPlans.AddRange(basic, premium);
                context.SaveChanges();
            }

            // Abonnements
            if (!context.Abonnements.Any())
            {
                var basicPlan = context.AbonnementPlans.First(plan => plan.Nom == "Standard");

                var abonnement = new Abonnement
                {
                    DateDebut = DateTime.Today.AddDays(-10),
                    DateFin = null,
                    RenouvellementAuto = true,
                    MembreId = membrePrincipal.Id,
                    PlanId = basicPlan.Id
                };

                context.Abonnements.Add(abonnement);
                context.SaveChanges();
            }

            // Catégories
            if (!context.Categories.Any())
            {
                var categories = new List<Categorie>
                {
                    new Categorie { Nom = "Action" },
                    new Categorie { Nom = "Aventure" },
                    new Categorie { Nom = "Science-fiction" },
                    new Categorie { Nom = "Fantastique" },
                    new Categorie { Nom = "Comédie" },
                    new Categorie { Nom = "Drame" },
                    new Categorie { Nom = "Horreur" },
                    new Categorie { Nom = "Thriller" },
                    new Categorie { Nom = "Animation" },
                    new Categorie { Nom = "Documentaire" },
                    new Categorie { Nom = "Romance" },
                    new Categorie { Nom = "Crime" },
                    new Categorie { Nom = "Guerre" },
                    new Categorie { Nom = "Historique" },
                    new Categorie { Nom = "Musical" },
                    new Categorie { Nom = "Mystère" },
                    new Categorie { Nom = "Super-héros" },
                    new Categorie { Nom = "Western" },
                    new Categorie { Nom = "Biographie" },
                    new Categorie { Nom = "Familial" },
                    new Categorie { Nom = "Sport" },
                    new Categorie { Nom = "Noir" },
                    new Categorie { Nom = "Policier" },
                    new Categorie { Nom = "Fantasy urbaine" }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            var cat = context.Categories.ToDictionary(c => c.Nom, c => c);

            if (!context.PistesAudio.Any())
            {
                context.PistesAudio.RemoveRange(context.PistesAudio);
                context.SaveChanges();

                var pisteAudios = new List<PisteAudio>
                {
                    new PisteAudio
                    {
                        Langue = "Anglais"
                    },
                    new PisteAudio
                    {
                        Langue = "Francais"
                    },
                     new PisteAudio
                    {
                        Langue = "Espagnol"
                    },
                      new PisteAudio
                    {
                        Langue = "Allemand"
                    },
                       new PisteAudio
                    {
                        Langue = "Mandarin"
                    },
                        new PisteAudio
                    {
                        Langue = "Arabe"
                    },
                            new PisteAudio
                    {
                        Langue = "Japonais"
                    }
                };
                context.PistesAudio.AddRange(pisteAudios);
                context.SaveChanges();
            }

            if (!context.PistesSousTitre.Any())
            {
                context.PistesSousTitre.RemoveRange(context.PistesSousTitre);
                context.SaveChanges();

                var pisteSousTitre = new List<PisteSousTitre>
                {
                    new PisteSousTitre
                    {
                        Langue = "Anglais"
                    },
                    new PisteSousTitre
                    {
                        Langue = "Francais"
                    },
                     new PisteSousTitre
                    {
                        Langue = "Espagnol"
                    },
                      new PisteSousTitre
                    {
                        Langue = "Allemand"
                    },
                       new PisteSousTitre
                    {
                        Langue = "Mandarin"
                    },
                        new PisteSousTitre
                    {
                        Langue = "Arabe"
                    },
                            new PisteSousTitre
                    {
                        Langue = "Japonais"
                    },
                            new PisteSousTitre
                    {
                        Langue = "Coréen"
                    },
                            new PisteSousTitre
                    {
                        Langue = "Italien"
                    },
                };
                context.PistesSousTitre.AddRange(pisteSousTitre);
                context.SaveChanges();
            }
            // Films
            if (!context.Films.Any())
            {
                var films = new List<Film>
                {
                    new Film
                    {
                        Titre = "The Matrix",
                        AnneeSortie = 1999,
                        Duree = 136,
                        Synopsis = "Un pirate informatique découvre la vérité sur la Matrice.",
                        Prix = 12.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "matrix.jpg",
                        BandeAnnoncePath = "matrix_trailer.mp4",
                        CategorieId = cat["Science-fiction"].Id,
                        MotsClés = "Action;Futur;Science-fiction;Cyberpunk",
                        PistesAudio = context.PistesAudio
                        .Where(p => p.Langue == "Anglais" || p.Langue == "Francais").ToList(),
                        SousTitres = context.PistesSousTitre
                        .Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Japonais" || p.Langue == "Arabe").ToList()
                    },
                    new Film
                    {
                        Titre = "Interstellar",
                        AnneeSortie = 2014,
                        Duree = 169,
                        Synopsis = "Une équipe d'explorateurs voyage à travers un trou de ver pour sauver l'humanité.",
                        Prix = 15.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "interstellar.jpg",
                        BandeAnnoncePath = "interstellar_trailer.mp4",
                        CategorieId = cat["Science-fiction"].Id,
                        MotsClés = "Espace;Aventure;Science-fiction;Famille",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais").ToList()
                    },

                    new Film
                    {
                        Titre = "Inception",
                        AnneeSortie = 2010,
                        Duree = 148,
                        Synopsis = "Un voleur infiltre les rêves pour implanter une idée.",
                        Prix = 14.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "inception.jpg",
                        BandeAnnoncePath = "inception_trailer.mp4",
                        CategorieId = cat["Action"].Id,
                        MotsClés = "Rêves;Action;Science-fiction;Thriller",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais" || p.Langue == "Espagnol").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Espagnol").ToList()
                    },
                    new Film
                    {
                        Titre = "Mad Max: Fury Road",
                        AnneeSortie = 2015,
                        Duree = 120,
                        Synopsis = "Dans un désert post-apocalyptique, une femme se rebelle contre un tyran.",
                        Prix = 13.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "madmax.jpg",
                        BandeAnnoncePath = "madmax_trailer.mp4",
                        CategorieId = cat["Action"].Id,
                        MotsClés = "Post-apocalyptique;Action;Aventure;Dystopie",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais" || p.Langue == "Allemand").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Allemand").ToList()
                    },

                    new Film
                    {
                        Titre = "The Godfather",
                        AnneeSortie = 1972,
                        Duree = 175,
                        Synopsis = "Le patriarche d'une famille mafieuse transfère le contrôle à son fils réticent.",
                        Prix = 11.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "godfather.jpg",
                        BandeAnnoncePath = "godfather_trailer.mp4",
                        CategorieId = cat["Crime"].Id,
                        MotsClés = "Mafia;Crime;Drame;Famille",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais" || p.Langue == "Italien").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Italien").ToList()
                    },
                    new Film
                    {
                        Titre = "Parasite",
                        AnneeSortie = 2019,
                        Duree = 132,
                        Synopsis = "Une famille pauvre s'infiltre progressivement dans la maison d'une famille riche.",
                        Prix = 13.49m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "parasite.jpg",
                        BandeAnnoncePath = "parasite_trailer.mp4",
                        CategorieId = cat["Drame"].Id,
                        MotsClés = "Inégalités sociales;Drame;Thriller;Noir",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Coréen" || p.Langue == "Anglais").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Coréen").ToList()
                    },

                    new Film
                    {
                        Titre = "The Shining",
                        AnneeSortie = 1980,
                        Duree = 146,
                        Synopsis = "Un gardien d'hôtel isolé sombre peu à peu dans la folie.",
                        Prix = 10.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "shining.jpg",
                        BandeAnnoncePath = "shining_trailer.mp4",
                        CategorieId = cat["Horreur"].Id,
                        MotsClés = "Horreur;Psychologique;Isolé;Fantôme",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais").ToList()
                    },
                    new Film
                    {
                        Titre = "Se7en",
                        AnneeSortie = 1995,
                        Duree = 127,
                        Synopsis = "Deux détectives traquent un tueur en série inspiré des sept péchés capitaux.",
                        Prix = 11.49m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "se7en.jpg",
                        BandeAnnoncePath = "se7en_trailer.mp4",
                        CategorieId = cat["Thriller"].Id,
                        MotsClés = "Crime;Thriller;Mystère;Psychologique",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais").ToList()
                    },

                    new Film
                    {
                        Titre = "Toy Story",
                        AnneeSortie = 1995,
                        Duree = 81,
                        Synopsis = "Les jouets d'un petit garçon prennent vie lorsque personne ne les regarde.",
                        Prix = 9.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "toystory.jpg",
                        BandeAnnoncePath = "toystory_trailer.mp4",
                        CategorieId = cat["Animation"].Id,
                        MotsClés = "Animation;Aventure;Comédie;Familial",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais" || p.Langue == "Francais").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Espagnol").ToList()
                    },
                    new Film
                    {
                        Titre = "Le Roi Lion",
                        AnneeSortie = 1994,
                        Duree = 88,
                        Synopsis = "Un jeune lion doit accepter son destin de roi.",
                        Prix = 9.99m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "lionking.jpg",
                        BandeAnnoncePath = "lionking_trailer.mp4",
                        CategorieId = cat["Familial"].Id,
                        MotsClés = "Animation;Aventure;Drame;Musical",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Espagnol").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Espagnol").ToList()
                    },

                    new Film
                    {
                        Titre = "Titanic",
                        AnneeSortie = 1997,
                        Duree = 195,
                        Synopsis = "Une histoire d'amour tragique à bord du Titanic.",
                        Prix = 12.49m,
                        Statut = FilmStatus.Disponible,
                        AffichePath = "titanic.jpg",
                        BandeAnnoncePath = "titanic_trailer.mp4",
                        CategorieId = cat["Romance"].Id,
                        MotsClés = "Romance;Drame;Historique;Tragédie",
                        PistesAudio = context.PistesAudio.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Allemand").ToList(),
                        SousTitres = context.PistesSousTitre.Where(p => p.Langue == "Anglais" || p.Langue == "Francais" || p.Langue == "Allemand" || p.Langue == "Italien").ToList()
                    }
                };

                context.Films.AddRange(films);
                context.SaveChanges();
            }

            var filmMatrix = context.Films.First(f => f.Titre == "The Matrix");
            var filmInception = context.Films.First(f => f.Titre == "Inception");

            // Cartes de crédit
            if (!context.CartesCredits.Any())
            {
                var compte = context.Comptes.First(c => c.MembreId == membrePrincipal.Id);

                var card = new CarteCredit
                {
                    Numero = "4111111111111111",
                    Titulaire = $"{membrePrincipal.Prenom} {membrePrincipal.Nom}",
                    Expiration = DateTime.Today.AddYears(2),
                    CompteId = compte.Id
                };

                context.CartesCredits.Add(card);
                context.SaveChanges();
            }

            // Transactions
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

            // Visionnements
            if (!context.Visionnements.Any())
            {
                var vis1 = new Visionnement
                {
                    Date = DateTime.Today.AddDays(-2),
                    ModeAcces = ModeAcces.Abonnement,
                    FilmId = filmMatrix.Id,
                    MembreId = membrePrincipal.Id
                };

                var vis2 = new Visionnement
                {
                    Date = DateTime.Today.AddDays(-1),
                    ModeAcces = ModeAcces.A_L_Unite,
                    FilmId = filmInception.Id,
                    MembreId = membrePrincipal.Id
                };

                context.Visionnements.AddRange(vis1, vis2);
                context.SaveChanges();
            }

            // Cotes
            if (!context.Cotes.Any())
            {
                var cote1 = new Cote
                {
                    Valeur = 5,
                    Commentaire = "Film culte, excellent.",
                    MembreId = membrePrincipal.Id,
                    FilmId = filmMatrix.Id
                };

                var cote2 = new Cote
                {
                    Valeur = 4,
                    Commentaire = "Très bon mais complexe.",
                    MembreId = membrePrincipal.Id,
                    FilmId = filmInception.Id
                };

                context.Cotes.AddRange(cote1, cote2);
                context.SaveChanges();
            }
        }
    }
}