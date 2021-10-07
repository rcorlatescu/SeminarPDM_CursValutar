using System;
using System.Collections.Generic;
using System.Text;
using Seminar.Services;
using SQLite;
namespace Seminar.Models
{
    class Curs
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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

        [Ignore]
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

        public static DateTime ObtineDataReferinta(DateTime data)
        {
            switch (data.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return data.AddDays(-1);
                case DayOfWeek.Sunday:
                    return data.AddDays(-2);
                case DayOfWeek.Monday:
                    if (data.Hour < 13)
                        return data.AddDays(-3);
                    break;
            }
            return data.ToUniversalTime().Hour< 10 ? data.AddDays(-1) : data;
        }
    }
}
