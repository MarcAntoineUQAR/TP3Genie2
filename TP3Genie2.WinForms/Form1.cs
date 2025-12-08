using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    public partial class Form1 : Form
    {
        private readonly IFilmRepository _filmRepository;

        public Form1(IFilmRepository filmRepository)
        {
            InitializeComponent();
            _filmRepository = filmRepository;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var film = _filmRepository.GetById(1);
            MessageBox.Show(film?.Titre ?? "Film introuvable");
        }
    }
}
