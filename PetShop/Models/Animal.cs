using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetShop.Models
{
    public class AnimalModel
    {
        [Column("idanimal")]
        public int Id { get; set; }
        [Column("nomeanimal")]
        public string Nome { get; set; }
        [Column("racaanimal")]
        public string Raca { get; set; }
        [Column("porteanimal")]
        public string Porte { get; set; }

        [JsonIgnore]
        public ClienteModel Cliente { get; set; }
        [ForeignKey("idcliente")]
        public int ClienteId { get; set; }

    }
}
