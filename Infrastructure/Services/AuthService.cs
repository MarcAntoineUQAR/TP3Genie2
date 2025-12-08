using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private Utilisateur? _currentUser;

        public AuthService(IAuthRepository repo)
        {
            _repo = repo;
        }

        public Utilisateur? Login(string username, string password)
        {
            var user = _repo.Login(username, password);

            if (user != null)
                _currentUser = user;

            return user;
        }

        public Utilisateur? GetLoggedUser()
        {
            return _currentUser;
        }

        public void CreateUser(Utilisateur user)
        {
            _repo.CreateUser(user);
        }

        public void CreateMember(Membre membre)
        {
            _repo.CreateMember(membre);
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}