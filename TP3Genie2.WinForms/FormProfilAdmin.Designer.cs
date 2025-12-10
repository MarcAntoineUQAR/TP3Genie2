using System.Drawing;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    partial class FormProfilAdmin
    {
        private Label lblTitre;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblEmail;

        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtEmail;

        private Button btnModifier;
        private Button btnSauvegarder;
        private Button btnRetour;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Text = "Profil";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(500, 400);

            lblTitre = new Label
            {
                Text = "Modifier votre profil",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(120, 20)
            };

            lblUsername = new Label { Text = "Nom d'utilisateur", Location = new Point(40, 80), AutoSize = true };
            txtUsername = new TextBox { Location = new Point(180, 78), Width = 240, Enabled = false };

            lblPassword = new Label { Text = "Mot de passe", Location = new Point(40, 130), AutoSize = true };
            txtPassword = new TextBox { Location = new Point(180, 128), Width = 240, Enabled = false };

            lblEmail = new Label { Text = "Email", Location = new Point(40, 180), AutoSize = true };
            txtEmail = new TextBox { Location = new Point(180, 178), Width = 240, Enabled = false };

            btnModifier = new Button
            {
                Text = "Modifier",
                BackColor = Color.FromArgb(60, 40, 200),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(40, 250),
                Size = new Size(120, 35)
            };

            btnSauvegarder = new Button
            {
                Text = "Enregistrer",
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(180, 250),
                Size = new Size(120, 35),
                Enabled = false
            };

            btnRetour = new Button
            {
                Text = "Retour",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(320, 250),
                Size = new Size(120, 35)
            };

            Controls.Add(lblTitre);
            Controls.Add(lblUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);

            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);

            Controls.Add(btnModifier);
            Controls.Add(btnSauvegarder);
            Controls.Add(btnRetour);
        }
    }
}