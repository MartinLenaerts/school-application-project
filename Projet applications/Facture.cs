namespace Projet_applications
{
    public class Facture
    {
        public int Id { get; set; }
        public double Prix { get; set; }

        public Facture(int id, double prix)
        {
            Id = id;
            Prix = prix;
        }
    }
}