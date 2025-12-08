using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.Infrastructure.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IUtilisateurRepository _repo;

        public UtilisateurService(IUtilisateurRepository repo)
        {
            _repo = repo;
        }

        public Utilisateur? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Utilisateur? GetByUsername(string username)
        {
            return _repo.GetByUsername(username);
        }

        public void Add(Utilisateur user)
        {
            _repo.Add(user);
        }

        public void Update(Utilisateur user)
        {
            _repo.Update(user);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
