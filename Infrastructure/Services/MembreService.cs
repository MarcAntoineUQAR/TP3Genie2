using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.Infrastructure.Services
{
    public class MembreService : IMembreService
    {
        private readonly IMembreRepository _repo;

        public MembreService(IMembreRepository repo)
        {
            _repo = repo;
        }

        public Membre? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Add(Membre membre)
        {
            _repo.Add(membre);
        }

        public void Update(Membre membre)
        {
            _repo.Update(membre);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
