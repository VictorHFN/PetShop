using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class ClienteModel
    {
        [Column("idcliente")]
        public int Id { get; set; }
        [Column("nomecliente")]
        public string Nome { get; set; }
        
    }
}
