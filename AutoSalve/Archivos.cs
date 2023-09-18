namespace GuardadoRDLC.AutoSalve
{
    public class LastSalveRDLC
    {
        #region Variables globales
        private string[]? Carpeta { get; }
        readonly private DateTime fecha;
        #endregion

        #region Constructores
        public LastSalveRDLC(string ruta, DateTime time)
        {
            //Retorna un array con todo las carpetas del directorio
            Carpeta = Directory.GetDirectories(Path.GetFullPath(ruta));

            //Fecha de la carpeta de los ultimos RDLC a guardar
            if (time <= new DateTime(0001, 01, 01))
            {
                SalveRDLC.FinalyProgram("Fecha no intoduccida");                              
            }
            else
            {
                fecha = time;
            }
        }
        #endregion

        #region Metodo busca las carpetas que tengan alguna modificacion (List<string>)

        public List<string> DirectorisModify()
        {
            List<string> list = new();
            if (Carpeta != null)
            {
                int NCarperas = Carpeta.GetLength(0) - 1;

                for (int i = 0; i <= NCarperas; i++)
                {
                    if (fecha < Directory.GetLastWriteTime(Carpeta[i]))
                    {
                        list.Add(Carpeta[i]);
                    }
                }

                if (list == null || list.Count < 1)
                {
                    return new List<string> { "Nada" };
                }

                return list;

            }
            else
            {
                list.Add("Nada");
                return list;
            }
        }
        #endregion

        #region Metodo para buscar archivos modificados dentro de las carpetas (List<string>[])

        public List<string>[] ArchivosModifyInDirectory(List<string> Directorys,string tipo)
        {
            List<string>[] ArchivosM = new List<string>[Directorys.Count];

            if (Directorys[0] != "Nada")
            {
                for (int i = 0; i < Directorys.Count; i++)
                {
                    ArchivosM[i] = ArchivosModify(Directorys[i],tipo);
                }

                if (ArchivosM.All(a => a.Contains("Nada")))
                {
                    Console.WriteLine("No se encontraron ARCHIVOS modificados en el dia de hoy");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron CARPETAS modificadas en el dia de hoy");
                ArchivosM[0] = new List<string> { "Nada" };
            }

            return ArchivosM;
        }
        #endregion

        #region M para buscar archivos modificadas (List<string>)
        public List<string> ArchivosModify(string ruta,string tipo)
        {
            string[] Archivos = Directory.GetFiles(ruta, "*" + tipo);
            List<string> list = new();

            if (Archivos != null)
            {
                int Narchivos = Archivos.GetLength(0) - 1;

                for (int i = 0; i <= Narchivos; i++)
                {
                    if (fecha < Directory.GetCreationTimeUtc(Archivos[i]))
                    {
                        list.Add(Archivos[i]);
                    }
                }

                if (list.Count > 0)
                {
                    return list;
                }
                else
                {
                    list.Add("Nada");
                    return list;
                }
            }
            else
            {
                list.Add("Nada");
                return list;
            }
        }
        #endregion

        #region Ver Carpeta
        public string[] VerCarpetas()
        {
            return Carpeta ?? new string[] { "Nada" };
        }
        #endregion
    }
}
