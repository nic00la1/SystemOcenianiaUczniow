using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOcenianiaUczniow.MVVM.Model
{
    public class Uczen
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Klasa { get; set; }
        public List<Ocena> Oceny { get; set; }
    }
}
