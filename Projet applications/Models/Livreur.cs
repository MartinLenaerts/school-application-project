using System;
using System.Threading;


namespace Projet_applications
{
    public class Livreur : Employee
    {
        public void prendreCommande()
        {
            CurrentCommande.Etat = Etat.Livraison;
        }

        public Annexe AjouterAnnexe(Annexe annexe)
        {
            CurrentCommande.Annexe.Add(annexe);
            return null;
        }


        public void EffectuerLivraison()
        {
            Console.WriteLine("Livraison en cours");
            Thread.Sleep(5000);
            Console.WriteLine("Livraison arrivée à destination");
        }

        public void EnvoyerConfirmation()
        {
            Console.WriteLine("Pizza livrée au client");
        }

        public void RecevoirPaiement()
        {
            //CurrentCommande.Facture.Prix = 
        }

        public void RecupererFacture()
        {

        }
    }

}