namespace PetShop.Models
{
    public class ServicoView
    {
       public ServicoModel Servico { get; set; }
       public IEnumerable<PetShopModel> PetShops { get; set; }
    }
}
