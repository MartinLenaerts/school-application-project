namespace Projet_applications
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Taille { get; set; }


        public Pizza(int id, string type, string taille)
        {
            Id = id;
            Type = type;
            Taille = taille;
        }

        public void GetPrix()
        {
            // TODO implement here
        }
    }

}