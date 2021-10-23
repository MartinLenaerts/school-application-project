namespace Projet_applications
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Taille taille { get; set; }
        public Type type { get; set; }

        public int prix { get; set; }

        public void GetPrix()
        {
            // TODO implement here
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}