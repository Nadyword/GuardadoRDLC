using GuardadoRDLC;
using GuardadoRDLC.AutoSalve;
using GuardadoRDLC.BD;
using GuardadoRDLC.Tools;

Procedure procedures = new();
View view = new();
bool Fin = true;
while (Fin)
{

    switch (Menu.Opciones())
    {
        case 1:
            procedures.SetDestino(Comprob.ComprDirec());
            Fin = Utilidad.RegresarAlMenu();
            break;

        case 2:
            procedures.SetPartida(Comprob.ComprDirec());
            Fin = Utilidad.RegresarAlMenu();
            break;

        case 3:
            procedures.SetTipo(Utilidad.PedirTipo());
            Fin = Utilidad.RegresarAlMenu();
            break;

        case 4:

            SalveRDLC.AutoGuardado(view.ViewDestino(), view.ViewPartida(),view.ViewTipo(),new DateTime(2022,12,31)) ;
            Fin = Utilidad.RegresarAlMenu();
            break;

        case 5:
            Console.WriteLine("\n\n Que tenga un feliz dia!!");
            Thread.Sleep(1500);
            Environment.Exit(0);
            break;
    }
}