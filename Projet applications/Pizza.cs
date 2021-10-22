namespace Projet_applications
{
    public class Pizza
    {
        public int Id { get; set; }
        public PizzaType TypePizza;
        public Taille TaillePizza;

        public Pizza(int id, PizzaType typePizza, Taille taillePizza)
        {
            Id = id;
            this.TypePizza = typePizza;
            this.TaillePizza = taillePizza;
        }



        public void getPrix()
        {
            // TODO implement here
        }
    }

}