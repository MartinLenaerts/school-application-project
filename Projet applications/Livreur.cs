using System;

namespace Projet_applications
{
    public class Livreur : Employee
    {
        public Livreur(int id, string nom, string prenom) : base(id, nom, prenom)
        {
        }


        public Annexe AjouterAnnexe()
        {
            // TODO implement here
            return null;
        }

        public void EffectuerLivraison()
        {
            // TODO implement here
        }


        public String EnvoyerConfirmation()
        {
            // TODO implement here
            return null;
        }


        /*  public ListPizza prendrePizza() {
              // TODO implement here
              return null;
          }*/

        public void RecevoirPaiement()
        {
            // TODO implement here
        }

        public void RecupererFacture()
        {
            // TODO implement here
        }
    }
}