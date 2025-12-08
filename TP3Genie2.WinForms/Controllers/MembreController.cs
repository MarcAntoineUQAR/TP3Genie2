using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms.Controllers
{
    public class MembreController
    {
        private readonly IMembreService _service;

        public MembreController(IMembreService service)
        {
            _service = service;
        }

        public Membre? GetById(int id)
        {
            return _service.GetById(id);
        }

        public void Add(Membre membre)
        {
            _service.Add(membre);
        }

        public void Update(Membre membre)
        {
            _service.Update(membre);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
