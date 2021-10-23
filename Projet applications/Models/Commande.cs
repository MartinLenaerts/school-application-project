using System;
using System.Collections.Generic;

namespace Projet_applications
{
    public class Commande
    {
        public int Id { get; set; }
        public string DateHeure { get; set; }
        public List<Pizza> Pizza { get; set; }
        public List<Annexe> Annexe { get; set; }
        public Client Client { get; set; }
        public Facture Facture { get; set; }
        public Commis Commis { get; set; }
        public Livreur Livreur { get; set; }
        public Cuisinier Cuisinier { get; set; }

        private Etat _etat;

        public Etat Etat
        {
            get { return _etat; }
            set
            {
                _etat = value;
                if (value == Etat.Preparation) Cuisinier.PreparerCommande(this);
                if (value == Etat.Livraison) Livreur.PrendreCommande();
                if (value == Etat.Ferme) Console.WriteLine("Commande terminée");
            }
        }

        private Pizza _lastPizzaAdded;
        
        public void GenerateFacture()
        {
            // TODO implement here
        }

        public Commande()
        {
            DateTime now = DateTime.Now;
            DateHeure = "" + now.Hour + "h" + now.Hour + " " + now.Day + "/" + now.Month + "/" + now.Year;
            Pizza = new List<Pizza>();
            Annexe = new List<Annexe>();
        }

        public override string ToString()
        {
            string res = "";
            if (Id != 0) res += "Commande n° : " + Id + "\r\n";
            if (DateHeure != "") res += "           Date et heure : " + DateHeure + "\r\n";
            if (!(Client is null)) res += "           " + Client + "\r\n";
            if (!(Commis is null)) res += "           Commis : " + Commis + "\r\n";
            if (!(Livreur is null)) res += "           Livreur : " + Livreur + "\r\n";
            if (!(Cuisinier is null)) res += "           Cuisinier : " + Cuisinier + "\r\n";
            if (!(Facture is null)) res += "           " + Facture + "\r\n";
            res += "           Pizzas : \r\n";
            foreach (var pizza in Pizza)
            {
                res += "                    - " + pizza + "\r\n";
            }

            res += "           Annexes : \r\n";
            foreach (var annexe in Annexe)
            {
                res += "                    - " + annexe + "\r\n";
            }

            return res;
        }


        public void AddPizza(Pizza pizza)
        {
            _lastPizzaAdded = pizza;
                Etat = Etat.Preparation;
            Pizza.Add(pizza);
        }
    }
}