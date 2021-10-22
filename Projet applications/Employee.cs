namespace Projet_applications
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        protected Employee(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }
    }
}