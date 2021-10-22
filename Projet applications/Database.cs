using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;


 namespace Projet_applications
{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");


            if (File.Exists("./database.sqlite3") == false)
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                System.Console.WriteLine("Created Database");

            }

            if (File.Exists("./database.sqlite3"))
            {
                System.Console.WriteLine("already exists");
           
            }

            /*void OpenConnection()
            {
                if(myConnection.State == System.Data.ConnectionState.Open)
                {
                    myConnection.Open();
                }
            }
            void CloseConnection()
            {
                if(myConnection.State != System.Data.ConnectionState.Closed)
                {
                    myConnection.Clone();
                }
            }*/

           
        }

       /* internal void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Clone();
            }
        }

        internal void OpenConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }*/
    }
}
