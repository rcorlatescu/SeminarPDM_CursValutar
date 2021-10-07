using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Models
{
    class Curs
    {
        public string Valuta { get; set; }
        public double Valoare { get; set; }
        public int Multiplicator { get; set; }
        public string Data { get; set; }//2021-10-06

        public Curs()
        {
            Multiplicator = 1;
        }

        //USD -> us.png
        //RON -> ro.png
        //EUR -> eu.png

        public string Drapel
        {
            get
            {
                return Valuta.Substring(0, 2).ToLower() + ".png";
            }
        }

        public override string ToString()
        {
            return Valuta;
        }
    }
}
