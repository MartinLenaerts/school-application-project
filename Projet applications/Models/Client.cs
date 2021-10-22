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

        public string Adresse { get; set; }

        public int Telephone { get; set; }

        public Client(int id, string nom, string prenom, string adresse, int telephone)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Telephone = telephone;
        }
    }
}