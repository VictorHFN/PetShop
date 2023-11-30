using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PetShop.Models
{
    public class AnimalModel
    {
        [Column("idanimal")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido!")]
        [Column("nomeanimal")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Raça requerida!")]
        [Column("racaanimal")]
        public string Raca { get; set; }

        [Required(ErrorMessage = "Porte requerido!")]
        [Column("porteanimal")]
        public string Porte { get; set; }


        [JsonIgnore]
        public ClienteModel Cliente { get; set; }

        [Required(ErrorMessage = "Tutor requerido!")]
        [ForeignKey("idcliente")]
        public int ClienteId { get; set; }

    }
}
