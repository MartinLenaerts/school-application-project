using System;

namespace Projet_applications
{
    public class App
    {
        public Commande Commande { get; set; }
        public Database Database { get; set; }
        public void Start()
        {
            Console.WriteLine("Bienvenue ! ");
            Console.WriteLine("Veuillez entrer votre numero de téléphone ");
            
        }
    }
}