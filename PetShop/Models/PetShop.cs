using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class PetShopModel
    {
        [Column("idpetshop")]
        public int Id { get; set; }
        [Column("nomepetshop")]
        public string Nome { get; set; }
        [Column("cnpjpetshop")]
        public string CNPJ { get; set; }
    }
}
