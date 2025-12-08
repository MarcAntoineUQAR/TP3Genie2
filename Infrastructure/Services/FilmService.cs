using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;

namespace TP3Genie2.Infrastructure.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repo;

        public FilmService(IFilmRepository repo)
        {
            _repo = repo;
        }

        public Film? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public List<Film> Search(string query)
        {
            return _repo.Search(query);
        }

        public void Add(Film film)
        {
            _repo.Add(film);
        }

        public void Update(Film film)
        {
            _repo.Update(film);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
