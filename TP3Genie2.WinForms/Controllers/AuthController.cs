using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms.Controllers
{
    public class AuthController
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        public Utilisateur? Login(string username, string password)
        {
            return _service.Login(username, password);
        }

        public Utilisateur? GetLoggedUser()
        {
            return _service.GetLoggedUser();
        }

        public void CreateUser(Utilisateur user)
        {
            _service.CreateUser(user);
        }

        public void CreateMember(Membre membre)
        {
            _service.CreateMember(membre);
        }
    }
}
