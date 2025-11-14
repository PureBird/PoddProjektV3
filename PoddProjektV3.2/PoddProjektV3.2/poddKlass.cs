using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoddProjektV3._2
{
public class Podd
    {
    public string Titel { get; set; }
    public int AntalAvsnitt { get; set; }
    public string Beskrivning { get; set; }

     public Podd(){}

    public Podd(string titel, int antalAvsnitt, string beskrivning)
     {
       Titel = titel;
       AntalAvsnitt = antalAvsnitt;
       Beskrivning = beskrivning;
        }
    }
}