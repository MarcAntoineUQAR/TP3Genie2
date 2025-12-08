using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms.Controllers
{
    public class AbonnementController
    {
        private readonly IAbonnementService _service;

        public AbonnementController(IAbonnementService service)
        {
            _service = service;
        }

        public Abonnement? GetByMembre(int membreId)
        {
            return _service.GetByMembre(membreId);
        }

        public void Add(Abonnement abonnement)
        {
            _service.Add(abonnement);
        }

        public void Update(Abonnement abonnement)
        {
            _service.Update(abonnement);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
