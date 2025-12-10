namespace TP3Genie2.WinForms
{
    partial class ConsulterSingleFilm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label labelLogo;
        private LinkLabel linkConsulterFilm;
        private LinkLabel linkProfil;
        private LinkLabel linkDeconnexion;
        private Label lblReturn;
        private Label lblTitle;

        private Label lblYearLabel;
        private Label lblDurationLabel;
        private Label lblPriceLabel;
        private Label lblStatusLabel;
        private Label lblCategoryLabel;
        private Label lblLanguagesLabel;
        private Label lblSubtitlesLabel;
        private Label lblKeywordsLabel;
        private Label lblSynopsisLabel;

        private Label lblYear;
        private Label lblDuration;
        private Label lblPrice;
        private Label lblStatus;
        private Label lblCategory;
        private Label lblLanguages;
        private Label lblSubtitles;
        private Label lblKeywords;
        private Label lblSynopsis;

        private PictureBox picturePoster;
        private Button btnCredits;
        private Button btnTrailer;
        private Button btnPlay;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.labelLogo = new Label();
            this.linkConsulterFilm = new LinkLabel();
            this.linkProfil = new LinkLabel();
            this.linkDeconnexion = new LinkLabel();
            this.lblReturn = new Label();
            this.lblTitle = new Label();

            this.lblYearLabel = new Label();
            this.lblDurationLabel = new Label();
            this.lblPriceLabel = new Label();
            this.lblStatusLabel = new Label();
            this.lblCategoryLabel = new Label();
            this.lblLanguagesLabel = new Label();
            this.lblSubtitlesLabel = new Label();
            this.lblKeywordsLabel = new Label();
            this.lblSynopsisLabel = new Label();

            this.lblYear = new Label();
            this.lblDuration = new Label();
            this.lblPrice = new Label();
            this.lblStatus = new Label();
            this.lblCategory = new Label();
            this.lblLanguages = new Label();
            this.lblSubtitles = new Label();
            this.lblKeywords = new Label();
            this.lblSynopsis = new Label();

            this.picturePoster = new PictureBox();
            this.btnCredits = new Button();
            this.btnTrailer = new Button();
            this.btnPlay = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).BeginInit();
            this.SuspendLayout();

            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(1456, 800);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            this.panelHeader.BackColor = Color.FromArgb(60, 40, 200);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 60;

            this.labelLogo.Text = "Netplix";
            this.labelLogo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.labelLogo.ForeColor = Color.White;
            this.labelLogo.AutoSize = true;
            this.labelLogo.Location = new Point(20, 12);

            this.linkConsulterFilm.Text = "Consulter Film";
            this.linkConsulterFilm.Location = new Point(210, 20);
            this.linkConsulterFilm.LinkColor = Color.White;
            this.linkConsulterFilm.ActiveLinkColor = Color.White;
            this.linkConsulterFilm.VisitedLinkColor = Color.White;
            this.linkConsulterFilm.Font = new Font("Segoe UI", 12);
            this.linkConsulterFilm.AutoSize = true;
            this.linkConsulterFilm.LinkBehavior = LinkBehavior.NeverUnderline;
            this.linkConsulterFilm.Click += new EventHandler(this.RetourLink_Click);

            this.linkProfil.Text = "Consulter Profil";
            this.linkProfil.Location = new Point(1150, 20);
            this.linkProfil.LinkColor = Color.White;
            this.linkProfil.ActiveLinkColor = Color.White;
            this.linkProfil.VisitedLinkColor = Color.White;
            this.linkProfil.Font = new Font("Segoe UI", 12);
            this.linkProfil.AutoSize = true;
            this.linkProfil.LinkBehavior = LinkBehavior.NeverUnderline;

            this.linkDeconnexion.Text = "Déconnexion";
            this.linkDeconnexion.Location = new Point(1300, 20);
            this.linkDeconnexion.LinkColor = Color.White;
            this.linkDeconnexion.ActiveLinkColor = Color.White;
            this.linkDeconnexion.VisitedLinkColor = Color.White;
            this.linkDeconnexion.Font = new Font("Segoe UI", 12);
            this.linkDeconnexion.AutoSize = true;
            this.linkDeconnexion.LinkBehavior = LinkBehavior.NeverUnderline;

            this.panelHeader.Controls.Add(this.labelLogo);
            this.panelHeader.Controls.Add(this.linkConsulterFilm);
            this.panelHeader.Controls.Add(this.linkProfil);
            this.panelHeader.Controls.Add(this.linkDeconnexion);

            this.lblReturn.Text = "← Retour";
            this.lblReturn.Font = new Font("Segoe UI", 14, FontStyle.Underline);
            this.lblReturn.Location = new Point(15, 80);
            this.lblReturn.AutoSize = true;
            this.lblReturn.Cursor = Cursors.Hand;
            this.lblReturn.ForeColor = Color.Black;
            this.lblReturn.Click += new EventHandler(this.RetourLink_Click);

            int leftX = 40;
            int labelWidth = 150;
            int valueX = leftX + labelWidth;
            int contentWidth = 600;
            int topStart = 120;

            // Title
            this.lblTitle.Font = new Font("Segoe UI", 36, FontStyle.Bold);
            this.lblTitle.Location = new Point(leftX, topStart);
            this.lblTitle.Size = new Size(750, 80);
            this.lblTitle.Text = "";
            this.lblTitle.ForeColor = Color.Black;

            int offset = topStart + 100;

            // Year
            this.lblYearLabel.Text = "Année de sortie:";
            this.lblYearLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblYearLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblYearLabel.Location = new Point(leftX, offset);
            this.lblYearLabel.AutoSize = true;

            this.lblYear.Text = "";
            this.lblYear.Font = new Font("Segoe UI", 11);
            this.lblYear.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblYear.Location = new Point(valueX, offset);
            this.lblYear.AutoSize = true;

            offset += 30;

            // Duration
            this.lblDurationLabel.Text = "Durée:";
            this.lblDurationLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblDurationLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblDurationLabel.Location = new Point(leftX, offset);
            this.lblDurationLabel.AutoSize = true;

            this.lblDuration.Text = "";
            this.lblDuration.Font = new Font("Segoe UI", 11);
            this.lblDuration.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblDuration.Location = new Point(valueX, offset);
            this.lblDuration.AutoSize = true;

            offset += 30;

            // Price
            this.lblPriceLabel.Text = "Prix:";
            this.lblPriceLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblPriceLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblPriceLabel.Location = new Point(leftX, offset);
            this.lblPriceLabel.AutoSize = true;

            this.lblPrice.Text = "";
            this.lblPrice.Font = new Font("Segoe UI", 11);
            this.lblPrice.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblPrice.Location = new Point(valueX, offset);
            this.lblPrice.AutoSize = true;

            offset += 30;

            // Status
            this.lblStatusLabel.Text = "Status:";
            this.lblStatusLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblStatusLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblStatusLabel.Location = new Point(leftX, offset);
            this.lblStatusLabel.AutoSize = true;

            this.lblStatus.Text = "";
            this.lblStatus.Font = new Font("Segoe UI", 11);
            this.lblStatus.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblStatus.Location = new Point(valueX, offset);
            this.lblStatus.AutoSize = true;

            offset += 35;

            // Category
            this.lblCategoryLabel.Text = "Catégorie:";
            this.lblCategoryLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblCategoryLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblCategoryLabel.Location = new Point(leftX, offset);
            this.lblCategoryLabel.AutoSize = true;

            this.lblCategory.Text = "";
            this.lblCategory.Font = new Font("Segoe UI", 11);
            this.lblCategory.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblCategory.Location = new Point(valueX, offset);
            this.lblCategory.AutoSize = true;

            offset += 35;

            // Languages
            this.lblLanguagesLabel.Text = "Langues Disponibles:";
            this.lblLanguagesLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblLanguagesLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblLanguagesLabel.Location = new Point(leftX, offset);
            this.lblLanguagesLabel.AutoSize = true;

            this.lblLanguages.Text = "";
            this.lblLanguages.Font = new Font("Segoe UI", 11);
            this.lblLanguages.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblLanguages.Location = new Point(leftX, offset + 25);
            this.lblLanguages.Size = new Size(contentWidth, 40);

            offset += 60;

            // Subtitles
            this.lblSubtitlesLabel.Text = "Sous-titres disponibles:";
            this.lblSubtitlesLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSubtitlesLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblSubtitlesLabel.Location = new Point(leftX, offset);
            this.lblSubtitlesLabel.AutoSize = true;

            this.lblSubtitles.Text = "";
            this.lblSubtitles.Font = new Font("Segoe UI", 11);
            this.lblSubtitles.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblSubtitles.Location = new Point(leftX, offset + 25);
            this.lblSubtitles.AutoSize = true;

            offset += 55;

            // Keywords
            this.lblKeywordsLabel.Text = "Mots clés:";
            this.lblKeywordsLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblKeywordsLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblKeywordsLabel.Location = new Point(leftX, offset);
            this.lblKeywordsLabel.AutoSize = true;

            this.lblKeywords.Text = "";
            this.lblKeywords.Font = new Font("Segoe UI", 11);
            this.lblKeywords.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblKeywords.Location = new Point(leftX, offset + 25);
            this.lblKeywords.Size = new Size(contentWidth, 60);

            offset += 70;

            // Synopsis
            this.lblSynopsisLabel.Text = "Synopsis:";
            this.lblSynopsisLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lblSynopsisLabel.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblSynopsisLabel.Location = new Point(leftX, offset);
            this.lblSynopsisLabel.AutoSize = true;

            this.lblSynopsis.Text = "";
            this.lblSynopsis.Font = new Font("Segoe UI", 11);
            this.lblSynopsis.ForeColor = Color.FromArgb(60, 60, 60);
            this.lblSynopsis.Location = new Point(leftX, offset + 25);
            this.lblSynopsis.Size = new Size(contentWidth, 70);

            offset += 130;

            // Credits Button
            this.btnCredits.Text = "Consulter crédits";
            this.btnCredits.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnCredits.BackColor = Color.FromArgb(60, 40, 200);
            this.btnCredits.ForeColor = Color.White;
            this.btnCredits.Location = new Point(leftX, offset);
            this.btnCredits.Size = new Size(260, 50);
            this.btnCredits.FlatStyle = FlatStyle.Flat;
            this.btnCredits.Cursor = Cursors.Hand;

            // Vertical separator line
            Panel separator = new Panel();
            separator.BackColor = Color.Gray;
            separator.Location = new Point(875, 135);
            separator.Size = new Size(2, 580);

            // Picture Poster
            this.picturePoster.Location = new Point(915, 135);
            this.picturePoster.Size = new Size(500, 480);
            this.picturePoster.SizeMode = PictureBoxSizeMode.Zoom;
            this.picturePoster.BorderStyle = BorderStyle.FixedSingle;

            // Trailer Button
            this.btnTrailer.Text = "Visionner Bande-Annonce";
            this.btnTrailer.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnTrailer.BackColor = Color.FromArgb(60, 40, 200);
            this.btnTrailer.ForeColor = Color.White;
            this.btnTrailer.Location = new Point(915, 625);
            this.btnTrailer.Size = new Size(500, 50);
            this.btnTrailer.FlatStyle = FlatStyle.Flat;
            this.btnTrailer.Cursor = Cursors.Hand;

            // Play Button
            this.btnPlay.Text = "Visionner Film";
            this.btnPlay.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnPlay.BackColor = Color.FromArgb(60, 40, 200);
            this.btnPlay.ForeColor = Color.White;
            this.btnPlay.Location = new Point(915, 685);
            this.btnPlay.Size = new Size(500, 50);
            this.btnPlay.FlatStyle = FlatStyle.Flat;
            this.btnPlay.Cursor = Cursors.Hand;

            // Add all controls to form
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.lblTitle);

            // Add label titles
            this.Controls.Add(this.lblYearLabel);
            this.Controls.Add(this.lblDurationLabel);
            this.Controls.Add(this.lblPriceLabel);
            this.Controls.Add(this.lblStatusLabel);
            this.Controls.Add(this.lblCategoryLabel);
            this.Controls.Add(this.lblLanguagesLabel);
            this.Controls.Add(this.lblSubtitlesLabel);
            this.Controls.Add(this.lblKeywordsLabel);
            this.Controls.Add(this.lblSynopsisLabel);

            // Add label values
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblLanguages);
            this.Controls.Add(this.lblSubtitles);
            this.Controls.Add(this.lblKeywords);
            this.Controls.Add(this.lblSynopsis);

            this.Controls.Add(separator);
            this.Controls.Add(this.picturePoster);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.btnTrailer);
            this.Controls.Add(this.btnPlay);

            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}