using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Services;

namespace TP3Genie2.WinForms
{
    public partial class FormConsulterFilms : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _provider;
        private readonly IFilmService _filmService;
        private readonly IUtilisateurService _userService;
        private readonly IMembreService _membreService;

        public FormConsulterFilms(
            IServiceProvider provider,
            IAuthService authService,
            IFilmService filmService,
            IUtilisateurService userService,
            IMembreService membreService)
        {
            _provider = provider;
            _authService = authService;
            _filmService = filmService;
            _userService = userService;
            _membreService = membreService;

            InitializeComponent();

            this.Load += FormConsulterFilms_Load;
            btnFiltrer.Click += BtnFiltrer_Click;
            btnClearFilters.Click += BtnClearFilters_Click;

            linkDeconnexion.Click += LinkDeconnexion_Click;
        }

        private void FormConsulterFilms_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadFilms();
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _filmService.GetAllCategories();
                cbCategorie.DataSource = categories;
                cbCategorie.DisplayMember = "Nom";
                cbCategorie.ValueMember = "Id";
                cbCategorie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement catégories : " + ex.Message);
            }
        }

        private void BtnFiltrer_Click(object sender, EventArgs e)
        {
            LoadFilms();
        }

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtTitre.Text = "";
            cbCategorie.SelectedIndex = -1;
            txtPrixMin.Text = "";
            txtPrixMax.Text = "";
            txtDuree.Text = "";
            txtPersonnalite.Text = "";
            txtMotsCles.Text = "";

            LoadFilms();
        }

        private void LoadFilms()
        {
            panelFilms.Controls.Clear();

            string titre = txtTitre.Text.Trim();

            var films = _filmService.Search(titre);

            if (cbCategorie.SelectedItem is Categorie cat)
                films = films.Where(f => f.CategorieId == cat.Id).ToList();

            if (decimal.TryParse(txtPrixMin.Text, out var prixMin))
                films = films.Where(f => f.Prix >= prixMin).ToList();

            if (decimal.TryParse(txtPrixMax.Text, out var prixMax))
                films = films.Where(f => f.Prix <= prixMax).ToList();

            if (int.TryParse(txtDuree.Text, out var duree))
                films = films.Where(f => f.Duree >= duree).ToList();

            foreach (var film in films)
                panelFilms.Controls.Add(CreateFilmCard(film));
        }

        private void LinkDeconnexion_Click(object sender, EventArgs e)
        {
            _authService.Logout();

            var login = _provider.GetRequiredService<FormLogin>();
            login.Show();
            this.Close();
        }

        private Panel CreateFilmCard(Film f)
        {
            var card = new Panel
            {
                Width = 220,
                Height = 360,
                Margin = new Padding(20),
                BorderStyle = BorderStyle.FixedSingle
            };

            var img = new PictureBox
            {
                Width = 220,
                Height = 260,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            string path = Path.Combine(Application.StartupPath, "Images", "Films", f.AffichePath);

            img.Image = File.Exists(path)
                ? Image.FromFile(path)
                : null;

            var lblTitle = new Label
            {
                Text = f.Titre,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = false,
                Top = 265,
                Width = 220,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblCat = new Label
            {
                Text = "Catégorie: " + f.Categorie?.Nom,
                AutoSize = false,
                Top = 290,
                Width = 220,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblInfo = new Label
            {
                Text = $"{f.Duree} min | {f.Prix}$",
                AutoSize = false,
                Top = 315,
                Width = 220,
                Height = 18,
                TextAlign = ContentAlignment.MiddleCenter
            };

            card.Controls.Add(img);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblCat);
            card.Controls.Add(lblInfo);

            return card;
        }
    }
}
