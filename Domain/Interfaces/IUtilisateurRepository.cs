using TP3Genie2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Genie2.Domain.Interfaces
{
    public interface IUtilisateurRepository
    {
        Utilisateur? GetById(int id);
        Utilisateur? GetByUsername(string username);
        void Add(Utilisateur user);
        void Update(Utilisateur user);
        void Delete(int id);
    }
}