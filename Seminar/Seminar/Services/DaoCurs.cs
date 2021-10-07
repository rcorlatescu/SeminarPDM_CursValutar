using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Seminar.Models;
using SQLite;
using SQLitePCL;

namespace Seminar.Services
{
    class DaoCurs
    {
        SQLiteConnection conn;
        public DaoCurs()
        {
            string cale = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "curs_valutar.db");
            conn = new SQLiteConnection(cale);
            conn.CreateTable<Curs>();

        }

        public int AdaugaCurs(Curs curs)
        {
            return conn.Insert(curs);
        }

        public int AdaugaListaCurs(List<Curs> listaCurs)
        {
            return conn.InsertAll(listaCurs);
        }

        public List<Curs> ObtineCursDinData(string data)
        {
            return conn.Query<Curs>("SELECT * FROM  Curs WHERE Data = ?", data);
        }
    }
}
