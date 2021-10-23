using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_applications
{
    public class Client
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Telephone { get; set; }

        public Adresse adresse;

        public Client(int id, string nom, string prenom, String rue, String ville, int numRue, int telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            adresse.Rue = rue;
            adresse.Ville = ville;
            adresse.NumRue = numRue;
            Telephone = telephone;
        }
    }
}