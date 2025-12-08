using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms
{
    public partial class FormLogin : Form
    {
        private readonly IAuthService _authService;
        private readonly IFilmService _filmService;
        private readonly IUtilisateurService _userService;
        private readonly IMembreService _membreService;

        private readonly IServiceProvider _provider;

        public FormLogin(IServiceProvider provider, IAuthService authService, IFilmService filmService, IUtilisateurService userService, IMembreService membreService)
        {
            _provider = provider;
            _authService = authService;
            _filmService = filmService;
            _userService = userService;
            _membreService = membreService;

            InitializeComponent();

            btnLogin.Click += BtnLogin_Click;
            linkRegister.Click += LinkRegister_Click;
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var user = _authService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
                return;
            }

            var filmPage = _provider.GetRequiredService<FormConsulterFilms>();
            filmPage.Show();
            this.Hide();
        }

        private void LinkRegister_Click(object sender, EventArgs e)
        {
            var register = _provider.GetRequiredService<FormRegister>();
            register.Show();
            this.Hide();
        }
    }
}
