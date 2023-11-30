using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class PetShopModel
    {
        [Column("idpetshop")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido!")]
        [Column("nomepetshop")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CNPJ requerido!")]
        [Column("cnpshop")]
        public string CNPJ { get; set; }
    }
}
