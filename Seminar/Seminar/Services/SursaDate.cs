using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Seminar.Models;

namespace Seminar.Services
{
    class SursaDate
    {
        public static async Task<List<Curs>> ObtineListaCurs()
        {
            /* List<Curs> listaCurs = new List<Curs>();
             listaCurs.Add(new Curs() { Valuta = "EUR", Valoare = 4.94, Data = "2021-10-06" });
             listaCurs.Add(new Curs() { Valuta = "USD", Valoare = 4.34, Data = "2021-10-06" });
             listaCurs.Add(new Curs() { Valuta = "GBP", Valoare = 5.44, Data = "2021-10-06" });
             listaCurs.Add(new Curs() { Valuta = "HUF", Valoare = 4.94, Data = "2021-10-06", Multiplicator = 100 });

             return listaCurs;*/

            return await PreiaCursXML();
        }

        private static async Task<List<Curs>> PreiaCursXML()
        {
            List<Curs> listaCurs = new List<Curs>();

            HttpClient httpClient = new HttpClient();
            Stream stream =await httpClient.GetStreamAsync("https://bnr.ro/nbrfxrates.xml");
            using (XmlReader reader = XmlReader.Create(stream))
            {
                string data = "";
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "Cube")
                        {
                            //preluare data
                            data = reader["date"];
                        }

                        if (reader.Name == "Rate")
                        {
                            //preluare curs
                            Curs curs = new Curs()
                            {
                                Valuta = reader["currency"],
                                Data = data

                            };

                            if (reader["multiplier"] != null)
                            {
                                curs.Multiplicator = int.Parse(reader["multiplier"]);
                            }

                            reader.Read();

                            curs.Valoare = double.Parse(reader.Value);

                            listaCurs.Add(curs);
                        }
                    }
                }
            }

            return listaCurs;
        }
    }
}
