using Microsoft.Extensions.DependencyInjection;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms
{
    public partial class ConsulterSingleFilm : Form
    {
        private readonly IFilmService _filmService;
        private readonly IServiceProvider _provider;

        public ConsulterSingleFilm(IFilmService filmService, IServiceProvider provider)
        {
            _provider = provider;
            _filmService = filmService;
            InitializeComponent();
        }

        public void InitializeFilm(int filmId)
        {
            LoadFilmData(filmId);
        }

        private void RetourLink_Click(object sender, EventArgs e)
        {
            var homepage = _provider.GetRequiredService<FormConsulterFilms>();
            homepage.Show();
            Hide();
        }

        private void LoadFilmData(int filmId)
        {
            var film = _filmService.GetById(filmId);

            lblTitle.Text = film.Titre;
            lblYear.Text = film.AnneeSortie.ToString();
            lblDuration.Text = $"{film.Duree} minutes";
            lblPrice.Text = film.Prix.ToString() + '$';
            lblStatus.Text = film.Statut.ToString();
            lblCategory.Text = film.Categorie.Nom.ToString();
            lblLanguages.Text = "";
            lblSubtitles.Text = "";
            lblKeywords.Text = "";
            foreach (PisteAudio pa in film.PistesAudio) {
                lblLanguages.Text += $"{pa.Langue}, ";
            }

            foreach (PisteSousTitre pst in film.SousTitres) {
                lblSubtitles.Text += $"{pst.Langue}, ";
            }
            var keywords = film.MotsClés
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(k => k.Trim())
            .ToList();
            foreach (string kw in keywords) {
                lblKeywords.Text += $"{kw}, ";
            }

            lblSynopsis.Text = film.Synopsis;

            picturePoster.SizeMode = PictureBoxSizeMode.StretchImage;
            picturePoster.ImageLocation = Path.Combine(Application.StartupPath, "Images", "Films", film.AffichePath);
        }
    }
}
