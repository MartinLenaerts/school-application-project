using System;
using System.Data.SQLite;

namespace Projet_applications
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App(){Database = new Database()};
            app.Start();
            
        }
    }
}