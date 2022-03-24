using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamsViagens.Models
{
	public class Comprar
	{	
		[Key]
		public int IdCompra { get; set; }
		public string Email { get; set; }
		[ForeignKey("CadastrarCarro")]
		public int Id_Destino { get; set; }
        public int Id_CadastrarCarro { get; set; }
        public virtual CadastrarDestino CadastrarDestino { get; set; }


	}
}
