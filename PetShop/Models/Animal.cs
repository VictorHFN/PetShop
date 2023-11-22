namespace PetShop.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Porte { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

    }
}
