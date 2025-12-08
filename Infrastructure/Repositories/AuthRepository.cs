using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;

namespace TP3Genie2.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public Utilisateur? Login(string username, string password)
        {
            return _context.Utilisateurs
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public Utilisateur? GetLoggedUser()
        {
            return null;
        }

        public void CreateUser(Utilisateur user)
        {
            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
        }

        public void CreateMember(Membre membre)
        {
            _context.Membres.Add(membre);
            _context.SaveChanges();
        }
    }
}