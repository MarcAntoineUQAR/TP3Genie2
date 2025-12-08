using TP3Genie2.Domain.Entities;
using TP3Genie2.Domain.Interfaces;
using TP3Genie2.Infrastructure.Data;

namespace TP3Genie2.Infrastructure.Repositories
{
	public class MembreRepository : IMembreRepository
	{
		private readonly AppDbContext _context;

		public MembreRepository(AppDbContext context)
		{
			_context = context;
		}

		public Membre? GetById(int id)
		{
			return _context.Membres.Find(id);
		}

		public void Add(Membre membre)
		{
			_context.Membres.Add(membre);
			_context.SaveChanges();
		}

		public void Update(Membre membre)
		{
			_context.Membres.Update(membre);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var membre = _context.Membres.Find(id);
			if (membre == null) return;

			_context.Membres.Remove(membre);
			_context.SaveChanges();
		}
	}
}
