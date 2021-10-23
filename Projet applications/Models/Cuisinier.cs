using System;
using System.Data.SQLite;
using System.Threading.Channels;

namespace Projet_applications
{
    public class Cuisinier : Employee
    {
        public Pizza PreparerPizza(Database db)
        {
            Pizza pizza = new Pizza();
            int id = 0;
            Console.WriteLine("Quelle Pizza préparer ?");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Preparation de la Pizza n° " + id);
            String query = "select id, taille, type, prix from Pizzas where id = " + id;
  
            SQLiteCommand myCommand = new SQLiteCommand(query, db.myConnection);

            SQLiteDataReader rdr = myCommand.ExecuteReader();
            pizza.Id = Convert.ToInt32(rdr["id"]);
            Type nomPizza = (Type)Enum.Parse(typeof(Type),Convert.ToString(rdr["type"]));
            Taille taillePizza = (Taille)Enum.Parse(typeof(Type),Convert.ToString(rdr["taille"]));
            pizza.taille = taillePizza;
            pizza.type = nomPizza;

            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Pizza faite : " + pizza.taille + ", " + pizza.type);


            // TODO implement here
            return pizza;
        }
    }
}