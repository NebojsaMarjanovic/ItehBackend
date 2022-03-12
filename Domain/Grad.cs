using System;
using System.Collections.Generic;

namespace Domain
{
    public class Grad
    {
        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public int Naseljenost { get; set; }
        public string Valuta { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }

    }
}
