
﻿using System;
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
                Console.WriteLine("Created Database");

            }

            if (File.Exists("./database.sqlite3"))
            {
                System.Console.WriteLine("already exists");
           
            }

           
        }

       
    }
}

