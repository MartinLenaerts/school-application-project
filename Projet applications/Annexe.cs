namespace Projet_applications
{
    public class Annexe
    {
        public string Nom { get; set; }

        public int Prix { get; set; }

        public double Volume { get; set; }

        public Annexe(string nom, int prix, double volume)
        {
            Nom = nom;
            Prix = prix;
            Volume = volume;
        }
    }
}