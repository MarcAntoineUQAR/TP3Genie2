using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class bdinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbonnementPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixMensuel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonnementPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypePersonne = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeSortie = table.Column<int>(type: "int", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    AffichePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandeAnnoncePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membres_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmCredits_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCredits_Personnes_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PistesAudio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Langue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistesAudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PistesAudio_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PistesSousTitre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Langue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PistesSousTitre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PistesSousTitre_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RenouvellementAuto = table.Column<bool>(type: "bit", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: true),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnements_AbonnementPlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "AbonnementPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonnements_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comptes_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valeur = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotes_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cotes_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visionnements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModeAcces = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visionnements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visionnements_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visionnements_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartesCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titulaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartesCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartesCredits_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_MembreId",
                table: "Abonnements",
                column: "MembreId",
                unique: true,
                filter: "[MembreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_PlanId",
                table: "Abonnements",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CartesCredits_CompteId",
                table: "CartesCredits",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_MembreId",
                table: "Comptes",
                column: "MembreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cotes_FilmId",
                table: "Cotes",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotes_MembreId",
                table: "Cotes",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCredits_FilmId",
                table: "FilmCredits",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCredits_PersonneId",
                table: "FilmCredits",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategorieId",
                table: "Films",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_UtilisateurId",
                table: "Membres",
                column: "UtilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PistesAudio_FilmId",
                table: "PistesAudio",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_PistesSousTitre_FilmId",
                table: "PistesSousTitre",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompteId",
                table: "Transactions",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Visionnements_FilmId",
                table: "Visionnements",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Visionnements_MembreId",
                table: "Visionnements",
                column: "MembreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnements");

            migrationBuilder.DropTable(
                name: "CartesCredits");

            migrationBuilder.DropTable(
                name: "Cotes");

            migrationBuilder.DropTable(
                name: "FilmCredits");

            migrationBuilder.DropTable(
                name: "PistesAudio");

            migrationBuilder.DropTable(
                name: "PistesSousTitre");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Visionnements");

            migrationBuilder.DropTable(
                name: "AbonnementPlans");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
