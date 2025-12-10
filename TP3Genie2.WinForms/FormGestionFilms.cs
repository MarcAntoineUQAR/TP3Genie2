using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Enums;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms
{
    public partial class FormGestionFilms : Form
    {
        private readonly IServiceProvider _provider;
        private readonly IAuthService _authService;
        private readonly IFilmService _filmService;

        private readonly string[] _availableLanguages =
        {
            "Français",
            "Anglais",
            "Espagnol",
            "Allemand",
            "Italien",
            "Japonais"
        };

        private List<Film> _currentFilms = new List<Film>();
        private Film? _selectedFilm;

        public FormGestionFilms(IServiceProvider provider, IAuthService authService, IFilmService filmService)
        {
            _provider = provider;
            _authService = authService;
            _filmService = filmService;

            InitializeComponent();

            // events
            this.Load += FormGestionFilms_Load;
            btnSearch.Click += BtnSearch_Click;
            lstFilms.SelectedIndexChanged += LstFilms_SelectedIndexChanged;

            btnClear.Click += BtnClear_Click;
            btnBrowsePoster.Click += BtnBrowsePoster_Click;

            btnAjouter.Click += BtnAjouter_Click;
            btnModifier.Click += BtnModifier_Click;
            btnSupprimer.Click += BtnSupprimer_Click;

            linkDeconnexion.LinkClicked += LinkDeconnexion_LinkClicked;
            linkConsulterFilm.LinkClicked += LinkConsulterFilm_LinkClicked;
        }

        // ========= INIT =========

        private void FormGestionFilms_Load(object? sender, EventArgs e)
        {
            // position right header links properly
            int rightMargin = 20;
            linkDeconnexion.Location = new Point(
                this.ClientSize.Width - linkDeconnexion.Width - rightMargin,
                linkDeconnexion.Location.Y);

            linkHeaderProfil.Location = new Point(
                linkDeconnexion.Left - linkHeaderProfil.Width - 25,
                linkHeaderProfil.Location.Y);

            lblTabProfil.Click += LblTabProfil_Click;

            // enum values for status
            cbStatut.DataSource = Enum.GetValues(typeof(FilmStatus));

            // categories
            LoadCategories();

            // languages
            LoadLanguages();

            // list
            LoadFilms();
        }

        private void LblTabProfil_Click(object? sender, EventArgs e)
        {
            var profil = _provider.GetRequiredService<FormProfilAdmin>();
            profil.Show();
            this.Hide();
        }

        private void LoadCategories()
        {
            try
            {
                var cats = _filmService.GetAllCategories();
                cbCategorie.DataSource = cats;
                cbCategorie.DisplayMember = "Nom";
                cbCategorie.ValueMember = "Id";
                cbCategorie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement catégories : " + ex.Message);
            }
        }

        private void LoadLanguages()
        {
            lstAudio.Items.Clear();
            lstSousTitres.Items.Clear();
            lstAudio.Items.AddRange(_availableLanguages);
            lstSousTitres.Items.AddRange(_availableLanguages);
        }

        // ========= FILM LIST =========

        private void LoadFilms()
        {
            string query = txtSearch.Text.Trim();
            _currentFilms = _filmService.Search(query).OrderBy(f => f.Titre).ToList();

            lstFilms.Items.Clear();
            foreach (var film in _currentFilms)
            {
                lstFilms.Items.Add(new FilmListItem(film));
            }

            if (_currentFilms.Count == 0)
            {
                _selectedFilm = null;
                ClearFormControls();
            }
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            LoadFilms();
        }

        private void LstFilms_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstFilms.SelectedItem is FilmListItem item)
            {
                _selectedFilm = item.Film;
                FillFormFromFilm(_selectedFilm);
            }
        }

        // ========= FORM <-> FILM MAPPING =========

        private void FillFormFromFilm(Film film)
        {
            ClearFormControls(false); // don’t reset lists, just selections

            txtTitre.Text = film.Titre;
            txtAnnee.Text = film.AnneeSortie.ToString();
            txtDuree.Text = film.Duree.ToString();
            cbStatut.SelectedItem = film.Statut;
            txtPrix.Text = film.Prix.ToString("0.00");

            if (cbCategorie.DataSource is List<Categorie> cats)
            {
                var cat = cats.FirstOrDefault(c => c.Id == film.CategorieId);
                cbCategorie.SelectedItem = cat;
            }

            txtPosterPath.Text = film.AffichePath ?? "";
            txtSynopsis.Text = film.Synopsis;

            // audio
            LoadLanguages(); // ensure list up to date
            for (int i = 0; i < lstAudio.Items.Count; i++)
            {
                string lang = lstAudio.Items[i].ToString()!;
                if (film.PistesAudio.Any(p => p.Langue == lang))
                    lstAudio.SetSelected(i, true);
            }

            // subtitles
            for (int i = 0; i < lstSousTitres.Items.Count; i++)
            {
                string lang = lstSousTitres.Items[i].ToString()!;
                if (film.SousTitres.Any(p => p.Langue == lang))
                    lstSousTitres.SetSelected(i, true);
            }
        }

        private void ClearFormControls(bool resetLists = true)
        {
            txtTitre.Text = "";
            txtAnnee.Text = "";
            txtDuree.Text = "";
            txtPrix.Text = "";
            txtPosterPath.Text = "";
            txtSynopsis.Text = "";
            cbStatut.SelectedIndex = -1;
            cbCategorie.SelectedIndex = -1;

            if (resetLists)
            {
                foreach (int i in lstAudio.SelectedIndices.Cast<int>().ToList())
                    lstAudio.SetSelected(i, false);
                foreach (int i in lstSousTitres.SelectedIndices.Cast<int>().ToList())
                    lstSousTitres.SetSelected(i, false);
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            _selectedFilm = null;
            lstFilms.ClearSelected();
            ClearFormControls();
        }

        // ========= POSTER =========

        private void BtnBrowsePoster_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Sélectionner une affiche",
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "Images", "Films");
                Directory.CreateDirectory(imagesFolder);

                string fileName = Path.GetFileName(ofd.FileName);
                string destination = Path.Combine(imagesFolder, fileName);

                if (!File.Exists(destination))
                    File.Copy(ofd.FileName, destination);

                txtPosterPath.Text = fileName; // we store only the filename
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la copie du fichier : " + ex.Message);
            }
        }

        // ========= ADD / UPDATE / DELETE =========

        private bool TryBuildFilmFromForm(out Film film, bool forExisting = false)
        {
            film = forExisting && _selectedFilm != null
                ? _selectedFilm
                : new Film();

            // validation
            if (string.IsNullOrWhiteSpace(txtTitre.Text))
            {
                MessageBox.Show("Le titre est obligatoire.");
                return false;
            }

            if (!int.TryParse(txtAnnee.Text, out int annee))
            {
                MessageBox.Show("Année de sortie invalide.");
                return false;
            }

            if (!int.TryParse(txtDuree.Text, out int duree))
            {
                MessageBox.Show("Durée invalide.");
                return false;
            }

            if (!decimal.TryParse(txtPrix.Text, out decimal prix))
            {
                MessageBox.Show("Prix invalide.");
                return false;
            }

            if (cbStatut.SelectedItem is not FilmStatus statut)
            {
                MessageBox.Show("Veuillez sélectionner un statut.");
                return false;
            }

            if (cbCategorie.SelectedItem is not Categorie cat)
            {
                MessageBox.Show("Veuillez sélectionner une catégorie.");
                return false;
            }

            // assign scalar properties
            film.Titre = txtTitre.Text.Trim();
            film.AnneeSortie = annee;
            film.Duree = duree;
            film.Prix = prix;
            film.Statut = statut;
            film.CategorieId = cat.Id;
            film.Synopsis = txtSynopsis.Text.Trim();
            film.AffichePath = string.IsNullOrWhiteSpace(txtPosterPath.Text)
                ? null
                : txtPosterPath.Text.Trim();

            // audio languages
            film.PistesAudio.Clear();
            foreach (var item in lstAudio.SelectedItems)
            {
                film.PistesAudio.Add(new PisteAudio
                {
                    Langue = item.ToString()!
                });
            }

            // subtitles
            film.SousTitres.Clear();
            foreach (var item in lstSousTitres.SelectedItems)
            {
                film.SousTitres.Add(new PisteSousTitre
                {
                    Langue = item.ToString()!
                });
            }

            return true;
        }

        private void BtnAjouter_Click(object? sender, EventArgs e)
        {
            if (!TryBuildFilmFromForm(out var newFilm, forExisting: false))
                return;

            try
            {
                _filmService.Add(newFilm);
                MessageBox.Show("Film ajouté avec succès.");
                LoadFilms();

                // select the new film
                var added = _currentFilms.FirstOrDefault(f => f.Id == newFilm.Id);
                if (added != null)
                {
                    var item = lstFilms.Items.Cast<FilmListItem>()
                        .FirstOrDefault(l => l.Film.Id == added.Id);
                    if (item != null)
                        lstFilms.SelectedItem = item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du film : " + ex.Message);
            }
        }

        private void BtnModifier_Click(object? sender, EventArgs e)
        {
            if (_selectedFilm == null)
            {
                MessageBox.Show("Veuillez sélectionner un film à modifier.");
                return;
            }

            if (!TryBuildFilmFromForm(out var film, forExisting: true))
                return;

            try
            {
                _filmService.Update(film);
                MessageBox.Show("Film modifié avec succès.");
                LoadFilms();

                var item = lstFilms.Items.Cast<FilmListItem>()
                    .FirstOrDefault(l => l.Film.Id == film.Id);
                if (item != null)
                    lstFilms.SelectedItem = item;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification du film : " + ex.Message);
            }
        }

        private void BtnSupprimer_Click(object? sender, EventArgs e)
        {
            if (_selectedFilm == null)
            {
                MessageBox.Show("Veuillez sélectionner un film à supprimer.");
                return;
            }

            if (MessageBox.Show("Voulez-vous vraiment supprimer ce film ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _filmService.Delete(_selectedFilm.Id);
                MessageBox.Show("Film supprimé avec succès.");
                _selectedFilm = null;
                LoadFilms();
                ClearFormControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }

        // ========= NAVIGATION / LOGOUT =========

        private void LinkDeconnexion_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            _authService.Logout();

            var login = _provider.GetRequiredService<FormLogin>();
            login.Show();
            this.Hide();
        }

        private void LinkConsulterFilm_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            var consulter = _provider.GetRequiredService<FormConsulterFilms>();
            consulter.Show();
            this.Hide();
        }

        private sealed class FilmListItem
        {
            public Film Film { get; }

            public FilmListItem(Film film) => Film = film;

            public override string ToString() =>
                $"{Film.Titre} ({Film.AnneeSortie})";
        }
    }
}
