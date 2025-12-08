using TP3Genie2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Genie2.Domain.Interfaces
{
    public interface IAuthService
    {
        Utilisateur? Login(string username, string password);
        Utilisateur? GetLoggedUser();
        void CreateUser(Utilisateur user);
        void CreateMember(Membre membre);
    }
}