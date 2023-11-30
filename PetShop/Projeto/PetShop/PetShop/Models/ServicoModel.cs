using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetShop.Models
{
    public class ServicoModel
    {
        [Column("idservico")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido!")]
        [Column("nomeservico")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição requerida!")]
        [Column("descricaoservico")]
        public string Descricao { get; set; }


        [JsonIgnore]
        public PetShopModel PetShop { get; set; }

        [Required(ErrorMessage = "Loja requerido!")]
        [ForeignKey("idpershop")]
        public int PetShopId { get; set; }
    }
}
