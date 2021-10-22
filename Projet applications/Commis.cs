
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Projet_applications;

public class Commis : Employee {

    public Commis() {
    }


    /// <summary>
    /// @return
    /// </summary>
    public String msgClient() {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @return
    /// </summary>
    public String msgCuisine() {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @return
    /// </summary>
    public String msgLivreur() {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @return
    /// </summary>
    public String msgCommis() {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @return
    /// </summary>
    /*public null recupererEtat() {
        // TODO implement here
        return null;
    }*/

    public void demanderFacture() {
        // TODO implement here
    }

    public void encaisser() {
        // TODO implement here
    }

    public void fermerCommande() {
        // TODO implement here
    }

    /// <summary>
    /// @return
    /// </summary>
    public int gererCumul() {
        // TODO implement here
        return 0;
    }

    /// <summary>
    /// @return
    /// </summary>
    public Facture genererFacture() {
        // TODO implement here
        return null;
    }

    /// <summary>
    /// @return
    /// </summary>
    public Commande creerCommande() {
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

        Console.WriteLine("nom" + nom + "prenom" + prenom + "ville" + ville + "tel" + tel + "date" + date + "numero de la rue" + numRue + "rue" + rue);

        String query = "insert into Client ('nom','prenom','ville','telephone','dateFirst','numeroRue','rue') values (@nom,@prenom,@ville,@telephone,@dateFirst,@numeroRue,@rue)";

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
        int id;
        int choixNom;
        int choixTaille;
        string nom;
        string taille;


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
                        String query = "select id from Pizzas where nom = \"" + nom + "\" and taille = \"" + taille + "\"";
                        SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
                        databaseObject.myConnection.Open();
                        SQLiteDataReader reader = myCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetInt32(0)}");
                            id = reader.GetInt32(0);
                            Console.WriteLine("id=" + id);
                        }
                        databaseObject.myConnection.Close();
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


    }

    /*public void AjouterPrixFacture(int id, Facture facture)
    {

        switch (type)
        {
            case 1:
                switch (taille)
                {
                    case 1:
                        String query = "select id from Pizzas where nom = 'quatreFromages' and taille = 'petite'";
                        SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
                        databaseObject.myConnection.Open();
                        facture.setPrix();
                        prix = myCommand.ExecuteNonQuery();
                        databaseObject.myConnection.Close();
                        break;


                }
                break;
        }

        Console.WriteLine("type" + type + "taille" + taille + ", cela vous fera un total de" + prix + "€");

    }*/

}