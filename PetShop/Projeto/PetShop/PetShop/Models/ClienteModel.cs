using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class ClienteModel
    {
        [Column("idcliente")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido!")]
        [Column("nomecliente")]
        public string Nome { get; set; }
        
    }
}
