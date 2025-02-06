using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOcenianiaUczniow.MVVM.Model
{
    public class Ocena
    {
        public string Przedmiot { get; set; }
        public double Wartosc { get; set; }
        public string Komentarz { get; set; }
        public string Data { get; set; }
    }
}
