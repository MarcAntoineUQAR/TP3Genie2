using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;

namespace TP3Genie2.Infrastructure.Repositories
{
    public class AbonnementRepository : IAbonnementRepository
    {
        private readonly AppDbContext _context;

        public AbonnementRepository(AppDbContext context)
        {
            _context = context;
        }

        public Abonnement? GetByMembre(int membreId)
        {
            return _context.Abonnements.FirstOrDefault(a => a.MembreId == membreId);
        }

        public void Add(Abonnement abonnement)
        {
            _context.Abonnements.Add(abonnement);
            _context.SaveChanges();
        }

        public void Update(Abonnement abonnement)
        {
            _context.Abonnements.Update(abonnement);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var abonn = _context.Abonnements.Find(id);
            if (abonn == null) return;

            _context.Abonnements.Remove(abonn);
            _context.SaveChanges();
        }
    }
}
