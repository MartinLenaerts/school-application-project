using System;
using System.IO;
using System.Data.SQLite;


namespace Projet_applications
{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            try
            {
                myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}