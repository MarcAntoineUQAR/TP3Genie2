using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Genie2.Domain.Enums;

namespace TP3Genie2.Domain.Entities
{
    public class PisteAudio
    {
        public int Id { get; set; }
        public string Langue { get; set; } = null!;

        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;
    }
}