using System.Drawing;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    partial class FormRegister
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelCard;
        private Label lblTitle;
        private Label lblAlreadyHaveAccount;
        private LinkLabel linkLogin;

        private Label lblFirstName;
        private TextBox txtFirstName;

        private Label lblLastName;
        private TextBox txtLastName;

        private Label lblUsername;
        private TextBox txtUsername;

        private Label lblEmail;
        private TextBox txtEmail;

        private Label lblPassword;
        private TextBox txtPassword;

        private Label lblAddress;
        private TextBox txtAddress;

        private Label lblPhone;
        private TextBox txtPhone;

        private Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Text = "Créer un compte";
            this.BackColor = Color.FromArgb(235, 235, 235);
            this.ClientSize = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            panelCard = new Panel()
            {
                BackColor = Color.White,
                Size = new Size(420, 580),
                Location = new Point(
                    (this.ClientSize.Width - 420) / 2,
                    (this.ClientSize.Height - 580) / 2
                ),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblTitle = new Label()
            {
                Text = "Créer un compte",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 40, 200),
                AutoSize = true,
                Location = new Point(110, 20)
            };

            lblAlreadyHaveAccount = new Label()
            {
                Text = "Vous avez déjà un compte?",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(90, 65)
            };

            linkLogin = new LinkLabel()
            {
                Text = "Ouvrir une session",
                AutoSize = true,
                Location = new Point(250, 65),
                Font = new Font("Segoe UI", 9)
            };

            lblFirstName = new Label()
            {
                Text = "Prénom",
                Location = new Point(90, 100),
                AutoSize = true
            };

            txtFirstName = new TextBox()
            {
                Location = new Point(90, 120),
                Width = 240
            };

            lblLastName = new Label()
            {
                Text = "Nom",
                Location = new Point(90, 160),
                AutoSize = true
            };

            txtLastName = new TextBox()
            {
                Location = new Point(90, 180),
                Width = 240
            };

            lblUsername = new Label()
            {
                Text = "Nom d'utilisateur",
                Location = new Point(90, 220),
                AutoSize = true
            };

            txtUsername = new TextBox()
            {
                Location = new Point(90, 240),
                Width = 240
            };

            lblEmail = new Label()
            {
                Text = "Adresse courriel",
                Location = new Point(90, 280),
                AutoSize = true
            };

            txtEmail = new TextBox()
            {
                Location = new Point(90, 300),
                Width = 240
            };

            lblPassword = new Label()
            {
                Text = "Mot de passe",
                Location = new Point(90, 340),
                AutoSize = true
            };

            txtPassword = new TextBox()
            {
                Location = new Point(90, 360),
                Width = 240,
                UseSystemPasswordChar = true
            };

            lblAddress = new Label()
            {
                Text = "Adresse",
                Location = new Point(90, 400),
                AutoSize = true
            };

            txtAddress = new TextBox()
            {
                Location = new Point(90, 420),
                Width = 240
            };

            lblPhone = new Label()
            {
                Text = "Téléphone",
                Location = new Point(90, 460),
                AutoSize = true
            };

            txtPhone = new TextBox()
            {
                Location = new Point(90, 480),
                Width = 240
            };

            btnRegister = new Button()
            {
                Text = "S’inscrire",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(240, 35),
                Location = new Point(90, 525)
            };

            panelCard.Controls.AddRange(new Control[]
            {
                lblTitle, lblAlreadyHaveAccount, linkLogin,
                lblFirstName, txtFirstName,
                lblLastName, txtLastName,
                lblUsername, txtUsername,
                lblEmail, txtEmail,
                lblPassword, txtPassword,
                lblAddress, txtAddress,
                lblPhone, txtPhone,
                btnRegister
            });

            this.Controls.Add(panelCard);
        }
    }
}