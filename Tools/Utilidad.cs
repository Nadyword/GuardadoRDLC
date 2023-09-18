using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardadoRDLC.Tools
{
    internal class Utilidad : Comprob
    {
        #region Ingresar tipos
        public static string PedirTipo()
        {
        repetir:
            Console.Clear();
            Console.WriteLine("Ingrese el tipo de archivo a buscar Ejemplo: .jpg\n");
            string tipo = "";
            bool repetir = true;

            while (repetir)
            {
                tipo = Console.ReadLine() ?? "Nada";

                if (tipo == "Nada")
                {
                    Console.WriteLine("Porfavor ingrese tipo de archivo\n");
                }
                else 
                {
                    tipo = "." + tipo.Replace(" ","").Replace(".","").Trim();
                    repetir = false;
                }
            }

            Console.WriteLine($"\nEl tipo de archivo que decea es {tipo}\nSeleccione una opcion\n1) Si\n2) No\n");
            int opc = SoloNum(1,2);

            if (opc == 1)
            {
                return tipo;
            }
            else 
            {
                goto repetir;
            }
        }
        #endregion

        #region Regresar al menu bool
        public static bool RegresarAlMenu()
        {
            Console.WriteLine("Operación exitosa!!\n\n Seleccione una opción:\n 1) Regresar al menú anterior\n 2) Salir de la aplicación");
            int opc = SoloNum(1,2);
            Console.Clear();

            if (opc == 2)
            {
                Console.WriteLine("\n\n Que tenga un feliz dia!!");
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
            return true;
        }
        #endregion
    }
}
