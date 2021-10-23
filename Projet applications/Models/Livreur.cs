using System;
using System.Threading;


namespace Projet_applications
{
    public class Livreur : Employee
    {
        public void PrendreCommande()
        {
            Console.WriteLine("Récupération de la commande");
            CurrentCommande.Etat = Etat.Livraison;
        }

        public void EffectuerLivraison(Commande c)
        {
            Console.WriteLine("Livraison en cours");
            Thread.Sleep(10000);
            c.Etat = Etat.Ferme;
            Console.WriteLine("Livraison arriv�e � destination");
        }
    }
}