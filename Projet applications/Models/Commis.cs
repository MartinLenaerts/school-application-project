
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Projet_applications;

namespace Projet_applications
{
    public class Commis : Employee
    {
        public Commis(int id, string nom, string prenom) : base(id, nom, prenom)
        {
        }

        public String MsgClient()
        {
            // TODO implement here
            return null;
        }


        public String MsgCuisine()
        {
            // TODO implement here
            return null;
        }


        public String MsgLivreur()
        {
            // TODO implement here
            return null;
        }


        public String MsgCommis()
        {
            // TODO implement here
            return null;
        }


        /* public null recupererEtat() {
             // TODO implement here
             return null;
         }*/
        public void DemanderFacture()
        {
            // TODO implement here
        }

        public void Encaisser()
        {
            // TODO implement here
        }

        public void FermerCommande()
        {
            // TODO implement here
        }


        public int GererCumul()
        {
            // TODO implement here
            return 0;
        }


        public Facture GenererFacture()
        {
            // TODO implement here
            return null;
        }


        public Commande CreerCommande()
        {
            // TODO implement here
            return null;
        }

        public void AjouterClient(Database databaseObject)
        {
            String nom;
            String prenom;
            String ville;
            double tel;
            String date;
            int numRue;
            String rue;


            Console.WriteLine("Saisissez un nom");
            nom = Console.ReadLine();

            Console.WriteLine("Saisissez un prenom");
            prenom = Console.ReadLine();

            Console.WriteLine("Saisissez une ville");
            ville = Console.ReadLine();

            Console.WriteLine("Saisissez un 06");
            tel = double.Parse(Console.ReadLine());

            Console.WriteLine("Saisissez une date");
            date = Console.ReadLine();

            Console.WriteLine("Saisissez un numero de rue");
            numRue = int.Parse(Console.ReadLine());

            Console.WriteLine("Saisissez une rue");
            rue = Console.ReadLine();

            Console.WriteLine("nom" + nom + "prenom" + prenom + "ville" + ville + "tel" + tel + "date" + date +
                              "numero de la rue" + numRue + "rue" + rue);

            String query =
                "insert into Client ('nom','prenom','ville','telephone','dateFirst','numeroRue','rue') values (@nom,@prenom,@ville,@telephone,@dateFirst,@numeroRue,@rue)";

            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.myConnection.Open();

            myCommand.Parameters.AddWithValue("@nom", nom);
            myCommand.Parameters.AddWithValue("@prenom", prenom);
            myCommand.Parameters.AddWithValue("@ville", ville);
            myCommand.Parameters.AddWithValue("@telephone", tel);
            myCommand.Parameters.AddWithValue("@dateFirst", date);
            myCommand.Parameters.AddWithValue("@numeroRue", numRue);
            myCommand.Parameters.AddWithValue("@rue", rue);
            var result = myCommand.ExecuteNonQuery();

            databaseObject.myConnection.Close();
            Console.WriteLine("Rows added : {0}", result);

        }

        public void AjouterPizzaCommande(Database databaseObject)
        {
            int id = 0;
            float prix = 0;
            int choixNom;
            int choixTaille;
            string nom = "";
            string taille = "";


            Console.WriteLine("Quelle type de pizza desirez-vous ?\r");
            Console.WriteLine("1- Quatre fromages\r");
            Console.WriteLine("2- Barbecue\r");
            Console.WriteLine("3- Veggie\r");
            choixNom = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Quelle taille souhaitez-vous pour votre pizza ?\r");
            Console.WriteLine("1- Petite\r");
            Console.WriteLine("2- Moyenne\r");
            Console.WriteLine("3- Grande\r");
            choixTaille = Convert.ToInt32(Console.ReadLine());


            switch (choixNom)
            {
                case 1:
                    switch (choixTaille)
                    {
                        case 1:
                            nom = "quatreFromages";
                            taille = "petite";
                            break;
                        case 2:
                            nom = "quatreFromages";
                            taille = "moyenne";
                            break;
                        case 3:
                            nom = "quatreFromages";
                            taille = "grande";
                            break;
                    }

                    break;
                case 2:
                    switch (choixTaille)
                    {
                        case 1:
                            nom = "barbecue";
                            taille = "petite";
                            break;
                        case 2:
                            nom = "barbecue";
                            taille = "moyenne";
                            break;
                        case 3:
                            nom = "barbecue";
                            taille = "grande";
                            break;
                    }

                    break;
                case 3:
                    switch (choixTaille)
                    {
                        case 1:
                            nom = "veggie";
                            taille = "petite";
                            break;
                        case 2:
                            nom = "veggie";
                            taille = "moyenne";
                            break;
                        case 3:
                            nom = "veggie";
                            taille = "grande";
                            break;
                    }

                    break;

            }
            string queryId = "select id from Pizzas where nom = \"" + nom + "\" and taille = \"" + taille + "\"";
            SQLiteCommand idCommand = new SQLiteCommand(queryId, databaseObject.myConnection);
            databaseObject.myConnection.Open();
            SQLiteDataReader readerId = idCommand.ExecuteReader();
            while (readerId.Read())
            {
                id = readerId.GetInt32(0);
            }

            string queryPrix = "select prix from Pizzas where id = " + id;
            SQLiteCommand prixCommand = new SQLiteCommand(queryPrix, databaseObject.myConnection);
            SQLiteDataReader readerPrix = prixCommand.ExecuteReader();
            while (readerPrix.Read())
            {
                prix = readerPrix.GetInt32(0);
            }
            databaseObject.myConnection.Close();
            Console.WriteLine("id=" + id);

            PizzaType nomPizza = (PizzaType) Enum.Parse(typeof(PizzaType), nom);
            Taille taillePizza = (Taille)Enum.Parse(typeof(PizzaType), nom);

            Pizza pizza = new Pizza(id, nomPizza, taillePizza);

            Commande commande = new Commande(1, DateTime.Now, pizza);

            Facture facture = new Facture(1, prix);
            facture.AjouterPrixFacture(prix);

        }

        public List<String> GetClients(Database databaseObject)
        {
            databaseObject.myConnection.Open();
            List<String> entries = new List<string>();
            String query = "select * from Client";

            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);


            SQLiteDataReader requete = myCommand.ExecuteReader();

            while (requete.Read())
            {
                entries.Add($"{requete.GetInt32(0)} {requete.GetString(1)} {requete.GetString(2)}");
            }


            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine(entries[i]);
            }


            return entries;
        }

        public void GetClientsByCity(Database databaseObject)
        {
            databaseObject.myConnection.Open();
            String query = "select * from Client order by ville";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            SQLiteDataReader rdr = myCommand.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetString(2)} {rdr.GetString(3)}");
            }

            databaseObject.myConnection.Close();
        }

        public Adresse trouverAdresse(Database databaseObject)
        {
            Adresse adresse = new Adresse();
            double tel = 0;
            Console.WriteLine("Saisissez le numero de telephone a partir duquel retrouver l'adresse");
            tel = double.Parse(Console.ReadLine());

            String rue = null;
            databaseObject.myConnection.Open();
            String query = "select rue, numeroRue, ville from Client where telephone =  " + tel;
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            SQLiteDataReader rdr = myCommand.ExecuteReader();
            bool rez = rdr.Read();
            Console.WriteLine(rez);
            adresse.Rue = Convert.ToString(rdr["rue"]);
            adresse.NumRue = Convert.ToInt32(rdr["numeroRue"]);
            adresse.Ville = Convert.ToString(rdr["ville"]);
            databaseObject.myConnection.Close();
            return adresse;
        }

    }
}