using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms
{
    public partial class FormProfilAdmin : Form
    {
        private readonly IServiceProvider _provider;
        private readonly IAuthService _authService;
        private readonly IUtilisateurService _userService;
        private readonly IMembreService _membreService;

        private Utilisateur? _current;

        public FormProfilAdmin(IServiceProvider provider, IAuthService authService, IUtilisateurService userService, IMembreService membreService)
        {
            _provider = provider;
            _authService = authService;
            _userService = userService;
            _membreService = membreService;

            InitializeComponent();

            this.Load += FormProfil_Load;
            btnModifier.Click += BtnModifier_Click;
            btnSauvegarder.Click += BtnSauvegarder_Click;
            btnRetour.Click += BtnRetour_Click;
        }

        private void FormProfil_Load(object? sender, EventArgs e)
        {
            _current = _authService.GetLoggedUser();
            if (_current == null)
            {
                MessageBox.Show("Aucun utilisateur connecté.");
                return;
            }

            txtUsername.Text = _current.Username;
            txtPassword.Text = _current.Password;
            txtEmail.Text = _current.Membre?.Email ?? "";
        }

        private void BtnModifier_Click(object? sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtEmail.Enabled = true;
            btnSauvegarder.Enabled = true;
        }

        private void BtnSauvegarder_Click(object? sender, EventArgs e)
        {
            if (_current == null) return;

            _current.Username = txtUsername.Text.Trim();
            _current.Password = txtPassword.Text.Trim();

            _userService.Update(_current);

            if (_current.Membre != null)
            {
                _current.Membre.Email = txtEmail.Text.Trim();
                _membreService.Update(_current.Membre);
            }

            MessageBox.Show("Profil mis à jour.");

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtEmail.Enabled = false;
            btnSauvegarder.Enabled = false;
        }

        private void BtnRetour_Click(object? sender, EventArgs e)
        {
            var gestion = _provider.GetRequiredService<FormGestionFilms>();
            gestion.Show();
            this.Hide();
        }
    }
}
