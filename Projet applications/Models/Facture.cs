namespace Projet_applications
{
    public class Facture
    {
        public int Id { get; set; }
        public double Prix { get; set; }
        public Commande Commande { get; set; }
    }
}