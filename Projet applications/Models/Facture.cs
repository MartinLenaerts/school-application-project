using System;

namespace Projet_applications
{
    public class Facture
    {
        public int Id { get; set; }
        public double Prix { get; set; }
        public Commande Commande { get; set; }
        
        public void AjouterPrixFacture(float prix)
        {
            Console.WriteLine("Le prix de votre pizza est de" + prix + "euros");
        }
    }
}