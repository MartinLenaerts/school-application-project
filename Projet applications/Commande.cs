using System;

namespace Projet_applications
{
    public class Commande
    {
        public int Id { get; set; }
        private DateTime DateHeure { get; set; }
        public Pizza _Pizza;

        public Commande(int id, DateTime dateHeure, Pizza pizza)
        {
            Id = id;
            this.DateHeure = dateHeure;
            this._Pizza = pizza;
        }


        public void GenerateFacture()
        {
            // TODO implement here
        }
    }
}