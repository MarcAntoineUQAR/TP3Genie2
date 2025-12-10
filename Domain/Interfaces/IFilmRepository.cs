using TP3Genie2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Genie2.Domain.Interfaces
{
    public interface IFilmRepository
    {
        Film? GetById(int id);
        List<Film> Search(string query);
        void Add(Film film);
        void Update(Film film);
        void Delete(int id);
        List<Categorie> GetAllCategories();
        List<Film> SearchByKeywords(string queryKeywords);
    }
}
