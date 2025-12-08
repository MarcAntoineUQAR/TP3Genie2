using TP3Genie2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Genie2.Domain.Interfaces
{
    public interface IAbonnementService
    {
        Abonnement? GetByMembre(int membreId);
        void Add(Abonnement abonnement);
        void Update(Abonnement abonnement);
        void Delete(int id);
    }
}