using Microsoft.EntityFrameworkCore;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;

namespace TP3Genie2.Infrastructure.Repositories
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly AppDbContext _context;

        public UtilisateurRepository(AppDbContext context)
        {
            _context = context;
        }

        public Utilisateur? GetById(int id)
        {
            return _context.Utilisateurs
                .Include(u => u.Membre)
                .FirstOrDefault(u => u.Id == id);
        }

        public Utilisateur? GetByUsername(string username)
        {
            return _context.Utilisateurs
                .Include(u => u.Membre)
                .FirstOrDefault(u => u.Username == username);
        }

        public void Add(Utilisateur user)
        {
            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
        }

        public void Update(Utilisateur user)
        {
            _context.Utilisateurs.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Utilisateurs.Find(id);
            if (user == null) return;

            _context.Utilisateurs.Remove(user);
            _context.SaveChanges();
        }
    }
}
