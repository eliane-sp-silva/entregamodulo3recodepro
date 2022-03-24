using System.ComponentModel.DataAnnotations;

namespace DreamsViagens.Models
{
    public class CadastrarDestino
    {
        [Key]
        public int Id_Destino {get; set;}
        public string Nome_Destino { get; set;}
        public string Preco { get; set;}
        public string Casal_Familia { get; set;}
        public virtual List<Comprar> Comprar { get; set; }



    }
}
