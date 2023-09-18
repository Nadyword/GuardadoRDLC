using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardadoRDLC.BD
{
    internal class View : Connection
    {

        public string ViewDestino()
        {
            using SQLiteConnection connect = new(ConnectionS);
            {
                string query = "SELECT Destino FROM Confi";
                connect.Open();
                using SQLiteCommand cmd = new(query, connect);
                {
                    SQLiteDataReader consulta = cmd.ExecuteReader();
                    while (consulta.Read())
                    {
                        query = consulta.GetString(0);
                    }
                    return query;
                }
            }
        }

        public string ViewPartida()
        {
            using SQLiteConnection connect = new(ConnectionS);
            {
                string query = "SELECT Partida FROM Confi";
                connect.Open();
                using SQLiteCommand cmd = new(query, connect);
                {
                    SQLiteDataReader consulta = cmd.ExecuteReader();
                    while (consulta.Read())
                    {
                        query = consulta.GetString(0);
                    }
                    return query;
                }
            }
        }

        public string ViewTipo()
        {
            using SQLiteConnection connect = new(ConnectionS);
            {
                string query = "SELECT tipo FROM Confi";
                connect.Open();
                using SQLiteCommand cmd = new(query, connect);
                {
                    SQLiteDataReader consulta = cmd.ExecuteReader();
                    while (consulta.Read())
                    {
                        query = consulta.GetString(0);
                    }
                    return query;
                }
            }
        }
    }
}
