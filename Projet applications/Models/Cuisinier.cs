using System;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Projet_applications
{
    public class Cuisinier : Employee
    {
        public async void PreparerCommande()
        {
            Console.WriteLine("Preparation de la commande n°"+ CurrentCommande.Id+" en cours");
            await Task.Delay(10000);
            CurrentCommande.Etat = Etat.Livraison;
            Console.WriteLine("Commande n°"+ CurrentCommande.Id+" prete");
        }
    }
}