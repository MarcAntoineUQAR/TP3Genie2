using System.Drawing;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    partial class FormConsulterFilms
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label labelLogo;
        private LinkLabel linkConsulterFilm;
        private LinkLabel linkProfil;
        private LinkLabel linkDeconnexion;

        private Panel panelSearch;
        private Label lblTitre;
        private TextBox txtTitre;
        private Label lblCategorie;
        private ComboBox cbCategorie;
        private Label lblPrix;
        private TextBox txtPrixMin;
        private TextBox txtPrixMax;
        private Label lblDuree;
        private TextBox txtDuree;
        private Label lblPersonnalite;
        private TextBox txtPersonnalite;
        private Label lblMotsCles;
        private TextBox txtMotsCles;

        private Button btnFiltrer;
        private Button btnClearFilters;

        private Label lblListeFilms;
        private FlowLayoutPanel panelFilms;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

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
                Location = new Point(150, 18),
                LinkColor = Color.White,
                AutoSize = true
            };

            linkProfil = new LinkLabel
            {
                Text = "Consulter Profil",
                Location = new Point(1690, 18),
                LinkColor = Color.White,
                AutoSize = true
            };

            linkDeconnexion = new LinkLabel
            {
                Text = "Déconnexion",
                Location = new Point(1820, 18),
                LinkColor = Color.White,
                AutoSize = true
            };

            panelHeader.Controls.Add(labelLogo);
            panelHeader.Controls.Add(linkConsulterFilm);
            panelHeader.Controls.Add(linkProfil);
            panelHeader.Controls.Add(linkDeconnexion);

            panelSearch = new Panel
            {
                BackColor = Color.FromArgb(230, 230, 230),
                Dock = DockStyle.Top,
                Height = 140
            };

            lblTitre = new Label { Text = "Titre", Location = new Point(20, 10) };
            txtTitre = new TextBox { Location = new Point(20, 35), Width = 140 };

            lblCategorie = new Label { Text = "Catégorie", Location = new Point(200, 10) };
            cbCategorie = new ComboBox { Location = new Point(200, 35), Width = 160 };

            lblPrix = new Label { Text = "Prix (min / max)", Location = new Point(400, 10) };
            txtPrixMin = new TextBox { Location = new Point(400, 35), Width = 60 };
            txtPrixMax = new TextBox { Location = new Point(470, 35), Width = 60 };

            lblDuree = new Label { Text = "Durée", Location = new Point(560, 10) };
            txtDuree = new TextBox { Location = new Point(560, 35), Width = 80 };

            lblPersonnalite = new Label { Text = "Personnalité", Location = new Point(20, 65) };
            txtPersonnalite = new TextBox { Location = new Point(20, 90), Width = 140 };

            lblMotsCles = new Label { Text = "Mots-Clés", Location = new Point(200, 65) };
            txtMotsCles = new TextBox { Location = new Point(200, 90), Width = 160 };

            btnFiltrer = new Button
            {
                Text = "Appliquer Filtre",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(400, 85),
                Width = 130,
                Height = 28
            };

            btnClearFilters = new Button
            {
                Text = "Réinitialiser",
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(540, 85),
                Width = 110,
                Height = 28
            };

            panelSearch.Controls.AddRange(new Control[]
            {
                lblTitre, txtTitre, lblCategorie, cbCategorie,
                lblPrix, txtPrixMin, txtPrixMax, lblDuree, txtDuree,
                lblPersonnalite, txtPersonnalite,
                lblMotsCles, txtMotsCles,
                btnFiltrer, btnClearFilters
            });


            lblListeFilms = new Label
            {
                Text = "Liste des films:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                Padding = new Padding(20, 5, 0, 0)
            };

            panelFilms = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(20)
            };


            this.Controls.Add(panelFilms);
            this.Controls.Add(lblListeFilms);
            this.Controls.Add(panelSearch);
            this.Controls.Add(panelHeader);

            this.Text = "Consulter Films";
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
