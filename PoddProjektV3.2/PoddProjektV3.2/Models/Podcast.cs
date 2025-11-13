using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoddProjektV3._2.Models
{
    public class Podcast
    {
        public string Titel { get; set; }
        public string Beskrivning { get; set; }
        public string? Kategori { get; set; }
        public List<Avsnitt> PoddAvsnitt { get; set; }
        public Podcast() { }
    }
}
