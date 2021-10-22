using System;

namespace Projet_applications
{
    public class Commande
    {
        public int Id { get; set; }
        private DateTime DateHeure { get; set; }

        public Commande(int id, DateTime dateHeure)
        {
            Id = id;
            this.DateHeure = dateHeure;
            Pizza pizza = new Pizza(1, "type", "taille");
        }

        public void GenerateFacture()
        {
            // TODO implement here
        }
    }
}