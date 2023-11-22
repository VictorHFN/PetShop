namespace PetShop.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Animal Animal { get; set; }
        public int AnimalId { get; set; }
    }
}
