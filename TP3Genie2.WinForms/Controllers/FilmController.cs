using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.WinForms.Controllers
{
    public class FilmController
    {
        private readonly IFilmService _service;

        public FilmController(IFilmService service)
        {
            _service = service;
        }

        public Film? GetById(int id)
        {
            return _service.GetById(id);
        }

        public List<Film> Search(string query)
        {
            return _service.Search(query);
        }

        public void Add(Film film)
        {
            _service.Add(film);
        }

        public void Update(Film film)
        {
            _service.Update(film);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
