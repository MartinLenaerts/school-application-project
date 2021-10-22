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
        }

        public void GenerateFacture()
        {
            // TODO implement here
        }
    }
}