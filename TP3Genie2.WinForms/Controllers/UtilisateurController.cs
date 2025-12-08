using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms.Controllers
{
    public class UtilisateurController
    {
        private readonly IUtilisateurService _service;

        public UtilisateurController(IUtilisateurService service)
        {
            _service = service;
        }

        public Utilisateur? GetById(int id)
        {
            return _service.GetById(id);
        }

        public Utilisateur? GetByUsername(string username)
        {
            return _service.GetByUsername(username);
        }

        public void Add(Utilisateur user)
        {
            _service.Add(user);
        }

        public void Update(Utilisateur user)
        {
            _service.Update(user);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
