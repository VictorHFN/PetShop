namespace PetShop.Models
{
    public class AnimalView
    {
       public AnimalModel Animal { get; set; }
       public IEnumerable<ClienteModel> Clientes { get; set; }
    }
}
