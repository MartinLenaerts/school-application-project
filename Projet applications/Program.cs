using System;
using System.Data.SQLite;

namespace Projet_applications
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            Database databaseObject = new Database();
            //Test insertion dans la database

            String query = "insert into Client ('nom','prenom','ville','telephone','numeroRue','rue') values (@nom,@prenom,@ville,@telephone,@numeroRue,@rue)";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.myConnection.Open();

            myCommand.Parameters.AddWithValue("@nom", "NGUYEN");
            myCommand.Parameters.AddWithValue("@prenom", "Nicolas");
            myCommand.Parameters.AddWithValue("@ville", "Fresnes");
            myCommand.Parameters.AddWithValue("@telephone", "0625147895");
            myCommand.Parameters.AddWithValue("@numeroRue", "10");
            myCommand.Parameters.AddWithValue("@rue", "rue AdolpheKara");
            var result = myCommand.ExecuteNonQuery();
      
            databaseObject.myConnection.Close();
            Console.WriteLine("Rows added : {0}", result);

            Commis commis = new Commis(1,"CommisNom","CommisPrenom");
            commis.AjouterClient(databaseObject);
            // commis.AjouterClient(databaseObject);

            commis.AjouterPizzaCommande(databaseObject);

            Console.ReadKey();
        }
    }
}
