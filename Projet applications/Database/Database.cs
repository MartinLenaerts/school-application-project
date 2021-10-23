using System;
using System.ComponentModel.Design;
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
        

        public SQLiteDataReader Select(string query)
        {
            SQLiteCommand myCommand = new SQLiteCommand(query, myConnection);
            return myCommand.ExecuteReader();
        }
        
        public void Open()
        {
            myConnection.Open();
        }
        
        
        public void Close()
        {
            myConnection.Close();
        }
    }
}