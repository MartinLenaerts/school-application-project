using System;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Channels;

namespace Projet_applications
{
    public class Cuisinier : Employee
    {
        public void PreparerCommande(Commande c)
        {
            Console.WriteLine("Preparation en cours");
            Thread.Sleep(10000);
            c.Etat = Etat.Livraison;
            Console.WriteLine("Prete");
        }
    }
}