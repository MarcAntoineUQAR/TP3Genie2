using System.Drawing;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelCard;
        private Label lblTitle;
        private Label lblNoAccount;
        private LinkLabel linkRegister;

        private Label lblUsername;
        private TextBox txtUsername;

        private Label lblPassword;
        private TextBox txtPassword;

        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Text = "Connexion";
            this.BackColor = Color.FromArgb(235, 235, 235);
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            panelCard = new Panel()
            {
                BackColor = Color.White,
                Size = new Size(380, 330),
                Location = new Point(
                    (this.ClientSize.Width - 380) / 2,
                    (this.ClientSize.Height - 330) / 2
                ),
                BorderStyle = BorderStyle.FixedSingle
            };
            panelCard.Anchor = AnchorStyles.None;

            lblTitle = new Label()
            {
                Text = "Ouvrir une session",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 40, 200),
                AutoSize = true,
                Location = new Point(75, 25)
            };

            lblNoAccount = new Label()
            {
                Text = "Vous n’avez pas de compte?",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(75, 65)
            };

            linkRegister = new LinkLabel()
            {
                Text = "S’inscrire",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(230, 65)
            };

            lblUsername = new Label()
            {
                Text = "Nom d'utilisateur",
                Location = new Point(75, 100),
                AutoSize = true
            };

            txtUsername = new TextBox()
            {
                Location = new Point(75, 120),
                Width = 230
            };

            lblPassword = new Label()
            {
                Text = "Mot de passe",
                Location = new Point(75, 160),
                AutoSize = true
            };

            txtPassword = new TextBox()
            {
                Location = new Point(75, 180),
                Width = 230,
                UseSystemPasswordChar = true
            };

            btnLogin = new Button()
            {
                Text = "Se connecter",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(75, 230),
                Size = new Size(230, 35)
            };

            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblNoAccount);
            panelCard.Controls.Add(linkRegister);
            panelCard.Controls.Add(lblUsername);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(lblPassword);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnLogin);

            this.Controls.Add(panelCard);
        }
    }
}
