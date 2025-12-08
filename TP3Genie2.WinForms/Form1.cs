using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using System;
using System.Windows.Forms;

namespace TP3Genie2.WinForms
{
    public partial class Form1 : Form
    {
        private readonly IFilmService _filmService;

        public Form1(IFilmService filmService)
        {
            InitializeComponent();
            _filmService = filmService;
        }
    }
}
