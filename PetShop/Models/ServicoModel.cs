using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetShop.Models
{
    public class ServicoModel
    {
        [Column("idservico")]
        public int Id { get; set; }
        [Column("nomeservico")]
        public string Nome { get; set; }
        [Column("descricaoservico")]
        public string Descricao { get; set; }

        [JsonIgnore]
        public PetShopModel PetShop { get; set; }
        [ForeignKey("idpershop")]
        public int PetShopId { get; set; }
    }
}
