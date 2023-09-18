using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuardadoRDLC.Tools;

namespace GuardadoRDLC
{
    internal class Menu : Comprob
    {
        public static int Opciones()
        {
            Console.WriteLine("Por favor ingresé el número de la opción deseada y luego presione enter\n");
            Console.WriteLine("1)- Cambiar la dirección de destino de los Backups.");
            Console.WriteLine("2)- Cambiar la dirección de partida de los archivos a respaldar.");
            Console.WriteLine("3)- Cambiar que tipo de archivo buscar para hacer los Backups.");
            Console.WriteLine("4)- <------Guardado automatico------>");
            Console.WriteLine("5)- Salir");
            return SoloNum(1,5);
        }
    }
}
