using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardadoRDLC.Tools
{
    internal class Comprob
    {
        #region Pedir solo numeros
        protected static int SoloNum(int des, int hasta)
        {
            bool Repetir;
            int resul = 0;
            string input;
            do
            {
                try
                {
                    input = Console.ReadLine() ?? "Nada";
                    resul = Convert.ToInt16(input);
                    if (resul >= des && resul <= hasta)
                    {
                        Repetir = false;
                    }
                    else 
                    {
                        Console.WriteLine("El numero esta fuera del rango!!");
                        Repetir = true;
                    }
                }
                catch
                {
                    Repetir = true;
                    Console.WriteLine("Solo tiene que ingresar numeros");
                }
            } while (Repetir);

            return resul;
        }
        #endregion

        #region Comprabar direccion
        public static string ComprDirec()
        {
            Console.Clear();
            Console.WriteLine("Ingrese una direccion:");
            do
            {
                string input = Console.ReadLine() ?? "Nada";
                if (Path.Exists(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("La dirección ingresada no existe, por favor ingresé una dirección válida");
                }
            } while (true);
        }

        #endregion
    }
}
