
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
   /* public null recupererEtat() {
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

}