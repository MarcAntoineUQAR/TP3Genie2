using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Enums;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms
{
    public partial class FormRegister : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _provider;

        public FormRegister(IServiceProvider provider, IAuthService authService)
        {
            _provider = provider;
            _authService = authService;

            InitializeComponent();

            btnRegister.Click += BtnRegister_Click;
            linkLogin.Click += LinkLogin_Click;
        }

        private void LinkLogin_Click(object sender, EventArgs e)
        {
            var login = _provider.GetRequiredService<FormLogin>();
            login.Show();
            this.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string prenom = txtFirstName.Text.Trim();
            string nom = txtLastName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (prenom == "" || nom == "" || username == "" || email == "" || password == "" || address == "" || phone == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var user = new Utilisateur
            {
                Username = username,
                Password = password,
                Role = UserRole.Membre
            };
            _authService.CreateUser(user);

            var membre = new Membre
            {
                Prenom = prenom,
                Nom = nom,
                Email = email,
                Adresse = address,
                Telephone = phone,
                UtilisateurId = user.Id,
                Compte = new Compte { Solde = 0 }
            };
            _authService.CreateMember(membre);

            MessageBox.Show("Votre compte a été créé avec succès!");

            var formLogin = _provider.GetRequiredService<FormLogin>();
            formLogin.Show();
            this.Close();
        }
    }
}