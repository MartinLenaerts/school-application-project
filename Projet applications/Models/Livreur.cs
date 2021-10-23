using System;
using System.Threading;
using System.Threading.Tasks;


namespace Projet_applications
{
    public class Livreur : Employee
    {
        public void PrendreCommande()
        {
            Console.WriteLine("Récupération de la commande n°" + CurrentCommande.Id);
            CurrentCommande.Etat = Etat.Pret;
        }

        public async void EffectuerLivraison()
        {
            Console.WriteLine("Livraison en cours");
            await Task.Delay(10000);
            CurrentCommande.Etat = Etat.Ferme;
            Console.WriteLine("Livraison de la commande n°"+CurrentCommande.Id + " effectuée");
        }
    }
}