using Microsoft.EntityFrameworkCore;
using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;

namespace TP3Genie2.Infrastructure.Repositories
{
	public class FilmRepository : IFilmRepository
	{
		private readonly AppDbContext _context;

		public FilmRepository(AppDbContext context)
		{
			_context = context;
		}

		public Film? GetById(int id)
		{
			return _context.Films
				.Include(f => f.Categorie)
				.Include(f => f.Credits)
				.Include(f => f.PistesAudio)
				.Include(f => f.SousTitres)
				.FirstOrDefault(f => f.Id == id);
		}

        public List<Film> Search(string query)
        {
            return _context.Films
                .Include(f => f.Categorie)
                .Where(f => f.Titre.Contains(query) || query == "")
                .ToList();
        }

        public void Add(Film film)
		{
			_context.Films.Add(film);
			_context.SaveChanges();
		}

		public void Update(Film film)
		{
			_context.Films.Update(film);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var film = _context.Films.Find(id);
			if (film == null) return;

			_context.Films.Remove(film);
			_context.SaveChanges();
		}

        public List<Categorie> GetAllCategories()
        {
            return _context.Categories
                .OrderBy(c => c.Nom)
                .ToList();
        }

		public List<Film> SearchByKeywords(string keywordsQuery)
		{
			return _context.Films
				.Where(f => f.MotsClés.Contains(keywordsQuery))
				.OrderBy(f => f.Titre).ToList();
		}
    }
}
