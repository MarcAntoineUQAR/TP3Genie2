using TP3Genie2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Genie2.Domain.Interfaces
{
    public interface IMembreRepository
    {
        Membre? GetById(int id);
        void Add(Membre membre);
        void Update(Membre membre);
        void Delete(int id);
    }
}
