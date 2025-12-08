using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;
using TP3Genie2.Infrastructure.Repositories;
using TP3Genie2.Infrastructure.Services;
using TP3Genie2.WinForms.Controllers;

namespace TP3Genie2.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FilmsDB;Trusted_Connection=True;TrustServerCertificate=True;";

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<Form1>();

            services.AddScoped<IAbonnementRepository, AbonnementRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IMembreRepository, MembreRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();

            services.AddScoped<IAbonnementService, AbonnementService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IMembreService, MembreService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUtilisateurService, UtilisateurService>();

            services.AddTransient<AbonnementController>();
            services.AddTransient<AuthController>();
            services.AddTransient<FilmController>();
            services.AddTransient<MembreController>();
            services.AddTransient<TransactionController>();
            services.AddTransient<UtilisateurController>();

            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<Form1>());
        }
    }
}