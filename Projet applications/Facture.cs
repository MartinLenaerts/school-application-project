using System;

namespace Projet_applications
{
    public class Facture
    {
        public int Id { get; set; }
        public float Prix { get; set; }

        public Facture(int id, float prix)
        {
            Id = id;
            Prix = prix;
        }

        public void AjouterPrixFacture(float prix)
        {
            Console.WriteLine("Le prix de votre pizza est de" + prix + "euros");
        }
    }
}