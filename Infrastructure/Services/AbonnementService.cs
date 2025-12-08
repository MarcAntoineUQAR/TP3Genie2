using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.Infrastructure.Services
{
    public class AbonnementService : IAbonnementService
    {
        private readonly IAbonnementRepository _repo;

        public AbonnementService(IAbonnementRepository repo)
        {
            _repo = repo;
        }

        public Abonnement? GetByMembre(int membreId)
        {
            return _repo.GetByMembre(membreId);
        }

        public void Add(Abonnement abonnement)
        {
            _repo.Add(abonnement);
        }

        public void Update(Abonnement abonnement)
        {
            _repo.Update(abonnement);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
