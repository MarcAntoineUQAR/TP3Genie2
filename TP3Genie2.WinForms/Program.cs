using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;
using TP3Genie2.Infrastructure.Repositories;
using TP3Genie2.Infrastructure.Services;

namespace TP3Genie2.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            var connectionString =
                "Server=(localdb)\\MSSQLLocalDB;Database=FilmsDB;Trusted_Connection=True;TrustServerCertificate=True;";

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddTransient<FormLogin>();
            services.AddTransient<FormConsulterFilms>();
            services.AddTransient<FormGestionFilms>();
            services.AddTransient<FormProfilAdmin>();

            services.AddScoped<FormLogin>();
            services.AddScoped<FormRegister>();

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

            services.AddTransient<ConsulterSingleFilm>();
            services.AddScoped<ConsulterSingleFilm>();

            var provider = services.BuildServiceProvider();

            services.AddSingleton<IServiceProvider>(provider);

            using (var scope = provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                DbInitializer.Initialize(db);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<FormLogin>());
        }
    }
}
