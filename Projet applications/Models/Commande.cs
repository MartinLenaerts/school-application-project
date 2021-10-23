using System;
using System.Collections.Generic;

namespace Projet_applications
{
    public class Commande
    {
        public int Id { get; set; }
        public DateTime DateHeure { get; set; }
        public List<Pizza> Pizza { get; set; }
        public List<Annexe> Annexe { get; set; }
        public Client Client { get; set; }
        public Facture Facture { get; set; }
        public Commis Commis { get; set; }
        public Livreur Livreur { get; set; }
        public Cuisinier Cuisinier { get; set; }
        public Etat Etat { get; set; }

        public void GenerateFacture()
        {
            // TODO implement here
        }
    }
}