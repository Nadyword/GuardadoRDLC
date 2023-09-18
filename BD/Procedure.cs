using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardadoRDLC.BD
{
    internal class Procedure : Connection
    {
        #region Cambiar destino int
        protected internal int SetDestino(string destino)
        {
            int resul = 0;
            using SQLiteConnection connec = new(ConnectionS);
            {
                connec.Open();
                string query = $"UPDATE Confi SET Destino = '{destino}'";
                using SQLiteCommand cmd = new(query, connec);
                {
                    resul = cmd.ExecuteNonQuery();                  
                }
                connec.Close();
            }
            return resul;
        }
        #endregion

        #region Cambiar partida int
        public int SetPartida(string partida)
        {
            int resul = 0;
            using SQLiteConnection connec = new(ConnectionS);
            {
                connec.Open();
                string query = $"UPDATE Confi SET Partida = '{partida}'";
                using SQLiteCommand cmd = new(query, connec);
                {
                    resul = cmd.ExecuteNonQuery();
                }
                connec.Close();
            }
            return resul;
        }
        #endregion

        #region Cambiar Tipo int
        public int SetTipo(string tipo)
        {
            int resul = 0;
            using SQLiteConnection connec = new(ConnectionS);
            {
                connec.Open();
                string query = $"UPDATE Confi SET Tipo = '{tipo}'";
                using SQLiteCommand cmd = new(query, connec);
                {
                    resul = cmd.ExecuteNonQuery();
                }
                connec.Close();
            }
            return resul;
        }
        #endregion
    }
}
