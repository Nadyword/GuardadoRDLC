using System.Data.SQLite;


namespace GuardadoRDLC.BD
{
    internal class Connection
    {
       protected SQLiteConnection ConnectionS = new("Data Source=BD.db;Version=3;");
    }
}
