namespace GuardadoRDLC.AutoSalve
{
    internal class SalveRDLC
    {
        #region Variable globales

        private string PathFolderASalve = "";
        readonly private DateTime hoy;
        private string SalveIn;

        #endregion

        #region Constructor

        public SalveRDLC(string path, DateTime time)
        {

            if (Directory.Exists(path))
            {
                PathFolderASalve = path;
            }
            else
            {
                Console.WriteLine("La ruta de la carpeta que introdujo no existe");
            }

            if (time <= new DateTime(0001, 01, 01))
            {
                FinalyProgram("Fecha no intoduccida");
                SalveIn = "";
            }
            else
            {
                hoy = time;
                SalveIn = CreateFolderTheNow();
            }
        }

        #endregion

        #region Crear carpeta del dia de hoy para el backup
        private string CreateFolderTheNow()
        {
            if (!Directory.Exists(Path.Combine(PathFolderASalve + "/" + hoy.ToString("dd-MM-yyyy"))))
            {
                DirectoryInfo ruta = Directory.CreateDirectory(PathFolderASalve + "/" + hoy.ToString("dd-MM-yyyy"));
                return PathFolderASalve = ruta.FullName.ToString();
            }

            return Path.GetFullPath(PathFolderASalve + "/" + hoy.ToString("dd-MM-yyyy"));
        }
        #endregion

        private void CreateFolderTheBackups(string Carpetas)
        {
            SalveIn = string.Concat(PathFolderASalve, "\\", Carpetas[(Carpetas.LastIndexOf('\\') + 1)..]);

            if (!Directory.Exists(SalveIn))
            {
                Directory.CreateDirectory(SalveIn);
            }
        }

        #region Guardar archivos
        public void SalveArchivo(List<string>[] archivos, List<string> carpeta)
        {
            for (int i = 0; i < carpeta.Count; i++)
            {
                CreateFolderTheBackups(carpeta[i]);

                if (archivos[i][0] != "Nada")
                {
                    for (int j = 0; j < archivos[i].Count; j++)
                    {

                        File.Copy(archivos[i][j], SalveIn + archivos[i][j][archivos[i][j].LastIndexOf('\\')..]);
                        Console.WriteLine($"El archivo {archivos[i][j]} fue copiado en : {SalveIn}");
                    }
                }
            }
        }
        #endregion

        #region Ver carpetas
        public string Vercarpeta()
        {
            CreateFolderTheNow();
            return PathFolderASalve;
        }
        #endregion

        #region Fin del programa

        public static void FinalyProgram(string msm)
        {
            Console.WriteLine(msm);
            Console.WriteLine("\nPrecion cualquier tecla para salir");
            Environment.Exit(0);
        }

        #endregion

        #region Programa de auto guardano
        public static void AutoGuardado(string Destino, string Partida, string tipo, DateTime DiaDePartida)
        {
            //Ruta de la carpeta principal de todos los RDLC
            LastSalveRDLC RDLC = new(Partida, DiaDePartida);

            //Busca que carpetas tiene archivos modificados
            List<string> CarpetasM = RDLC.DirectorisModify();

            //Buscar los archivos modificados dentro de las parpetas
            List<string>[] ArchivosM = RDLC.ArchivosModifyInDirectory(CarpetasM,tipo);

            //Ruta de carpeta principal de los respaldo de los RDLC
            SalveRDLC Salve = new(Destino, DiaDePartida);

            if (ArchivosM[0][0] != "Nada")
            {
                Salve.SalveArchivo(ArchivosM, CarpetasM);
                Console.WriteLine("\n <-------------Fin del programa------------->");
            }
        }
        #endregion
    }
}
