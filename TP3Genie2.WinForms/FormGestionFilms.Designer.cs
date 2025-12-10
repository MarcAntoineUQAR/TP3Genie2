using System.Drawing;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    partial class FormGestionFilms
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label labelLogo;
        private LinkLabel linkConsulterFilm;
        private LinkLabel linkHeaderProfil;
        private LinkLabel linkDeconnexion;

        private Panel panelTabs;
        private Label lblTabGestion;
        private Label lblTabStats;
        private Label lblTabProfil;

        private Panel panelLeft;
        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstFilms;

        private Panel panelRight;
        private Button btnClear;

        private Label lblTitre;
        private TextBox txtTitre;

        private Label lblAnnee;
        private TextBox txtAnnee;

        private Label lblDuree;
        private TextBox txtDuree;

        private Label lblStatut;
        private ComboBox cbStatut;

        private Label lblPrix;
        private TextBox txtPrix;

        private Label lblCategorie;
        private ComboBox cbCategorie;

        private Label lblLanguesAudio;
        private ListBox lstAudio;

        private Label lblSousTitres;
        private ListBox lstSousTitres;

        private Label lblPoster;
        private TextBox txtPosterPath;
        private Button btnBrowsePoster;

        private Label lblSynopsis;
        private TextBox txtSynopsis;

        private Label lblMotsCles;
        private TextBox txtMotsCles;

        private Button btnSupprimer;
        private Button btnModifier;
        private Button btnAjouter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Text = "Gestion des films";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            panelHeader = new Panel
            {
                BackColor = Color.FromArgb(60, 40, 200),
                Dock = DockStyle.Top,
                Height = 55
            };

            labelLogo = new Label
            {
                Text = "Netplix",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 8)
            };

            linkConsulterFilm = new LinkLabel
            {
                Text = "Consulter Film",
                LinkColor = Color.White,
                AutoSize = true,
                Location = new Point(150, 18)
            };

            linkHeaderProfil = new LinkLabel
            {
                Text = "Consulter Profil",
                LinkColor = Color.White,
                AutoSize = true
            };

            linkDeconnexion = new LinkLabel
            {
                Text = "Déconnexion",
                LinkColor = Color.White,
                AutoSize = true
            };

            panelHeader.Controls.Add(labelLogo);
            panelHeader.Controls.Add(linkConsulterFilm);
            panelHeader.Controls.Add(linkHeaderProfil);
            panelHeader.Controls.Add(linkDeconnexion);

            panelTabs = new Panel
            {
                Dock = DockStyle.Top,
                Height = 35,
                BackColor = Color.White
            };

            lblTabGestion = new Label
            {
                Text = "Gestion Films",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 8)
            };

            lblTabStats = new Label
            {
                Text = "Statistiques",
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(130, 8)
            };

            lblTabProfil = new Label
            {
                Text = "Profil",
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(230, 8)
            };

            panelTabs.Controls.Add(lblTabGestion);
            panelTabs.Controls.Add(lblTabStats);
            panelTabs.Controls.Add(lblTabProfil);

            panelLeft = new Panel
            {
                BackColor = Color.FromArgb(240, 240, 240),
                Width = 500,
                Dock = DockStyle.Left,
                Padding = new Padding(30)
            };

            txtSearch = new TextBox
            {
                Location = new Point(10, 10),
                Width = 280
            };

            btnSearch = new Button
            {
                Text = "Chercher",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(300, 8),
                Width = 120,
                Height = 30
            };

            lstFilms = new ListBox
            {
                Location = new Point(10, 50),
                Size = new Size(410, 450),
                Font = new Font("Segoe UI", 10),
                IntegralHeight = false
            };

            panelLeft.Controls.Add(txtSearch);
            panelLeft.Controls.Add(btnSearch);
            panelLeft.Controls.Add(lstFilms);

            panelRight = new Panel
            {
                BackColor = Color.FromArgb(245, 245, 245),
                Dock = DockStyle.Fill,
                Padding = new Padding(40)
            };

            btnClear = new Button
            {
                Text = "Vider",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 28),
                Location = new Point(900, 10)
            };

            int labelX = 20;
            int inputX = 180;
            int rowY = 40;
            int rowSpacing = 40;

            lblTitre = new Label { Text = "Titre", Location = new Point(labelX, rowY) };
            txtTitre = new TextBox { Location = new Point(inputX, rowY - 3), Width = 260 };

            rowY += rowSpacing;
            lblAnnee = new Label { Text = "Année de sortie", Location = new Point(labelX, rowY) };
            txtAnnee = new TextBox { Location = new Point(inputX, rowY - 3), Width = 80 };

            lblDuree = new Label { Text = "Durée (min)", Location = new Point(inputX + 120, rowY) };
            txtDuree = new TextBox { Location = new Point(inputX + 210, rowY - 3), Width = 80 };

            rowY += rowSpacing;
            lblStatut = new Label { Text = "Statut", Location = new Point(labelX, rowY) };
            cbStatut = new ComboBox { Location = new Point(inputX, rowY - 3), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };

            lblPrix = new Label { Text = "Prix ($)", Location = new Point(inputX + 200, rowY) };
            txtPrix = new TextBox { Location = new Point(inputX + 260, rowY - 3), Width = 80 };

            rowY += rowSpacing;
            lblCategorie = new Label { Text = "Catégorie", Location = new Point(labelX, rowY) };
            cbCategorie = new ComboBox { Location = new Point(inputX, rowY - 3), Width = 260, DropDownStyle = ComboBoxStyle.DropDownList };

            rowY += rowSpacing;
            lblLanguesAudio = new Label { Text = "Langues audio", Location = new Point(labelX, rowY) };
            lstAudio = new ListBox { Location = new Point(inputX, rowY + 20), Size = new Size(260, 70), SelectionMode = SelectionMode.MultiExtended };

            rowY += 100;
            lblSousTitres = new Label { Text = "Sous-titres", Location = new Point(labelX, rowY) };
            lstSousTitres = new ListBox { Location = new Point(inputX, rowY + 20), Size = new Size(260, 70), SelectionMode = SelectionMode.MultiExtended };

            rowY += 120;
            lblPoster = new Label { Text = "Poster", Location = new Point(labelX, rowY) };
            txtPosterPath = new TextBox { Location = new Point(inputX, rowY - 3), Width = 220 };
            btnBrowsePoster = new Button { Text = "...", Location = new Point(inputX + 230, rowY - 4), Size = new Size(30, 24) };

            rowY += rowSpacing;
            lblSynopsis = new Label { Text = "Synopsis", Location = new Point(labelX, rowY) };
            txtSynopsis = new TextBox
            {
                Location = new Point(inputX, rowY - 3),
                Width = 420,
                Height = 120,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            rowY = txtSynopsis.Bottom + 15;
            lblMotsCles = new Label { Text = "Mots-clés (séparés par ;)", Location = new Point(labelX, rowY) };
            txtMotsCles = new TextBox
            {
                Location = new Point(inputX, rowY - 3),
                Width = 420
            };

            int bottomY = txtMotsCles.Bottom + 20;

            btnSupprimer = new Button
            {
                Text = "Supprimer",
                BackColor = Color.Firebrick,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 35),
                Location = new Point(inputX, bottomY)
            };

            btnModifier = new Button
            {
                Text = "Modifier",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 35),
                Location = new Point(inputX + 150, bottomY)
            };

            btnAjouter = new Button
            {
                Text = "Ajouter",
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 35),
                Location = new Point(inputX + 300, bottomY)
            };

            panelRight.Controls.Add(btnClear);
            panelRight.Controls.AddRange(new Control[]
            {
                lblTitre, txtTitre,
                lblAnnee, txtAnnee,
                lblDuree, txtDuree,
                lblStatut, cbStatut,
                lblPrix, txtPrix,
                lblCategorie, cbCategorie,
                lblLanguesAudio, lstAudio,
                lblSousTitres, lstSousTitres,
                lblPoster, txtPosterPath, btnBrowsePoster,
                lblSynopsis, txtSynopsis,
                lblMotsCles, txtMotsCles,
                btnSupprimer, btnModifier, btnAjouter
            });

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.Controls.Add(panelTabs);
            this.Controls.Add(panelHeader);
        }
    }
}