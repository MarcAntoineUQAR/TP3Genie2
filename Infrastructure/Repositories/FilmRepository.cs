using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepository(AppDbContext context)
        {
            _context = context;
        }

        public Film GetFilmById(int id)
        {
            return _context.Films.Find(id);
        }

        public void AddFilm(Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
        }
    }
}
