using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TP3Genie2.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // Connexion MySQL
            var connectionString = "Server=localhost;Database=filmsdb;User=root;Password=admin123*;";

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Repository
            services.AddScoped<IFilmRepository, FilmRepository>();

            // Formulaire
            services.AddTransient<Form1>();

            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<Form1>());
        }
    }
}
