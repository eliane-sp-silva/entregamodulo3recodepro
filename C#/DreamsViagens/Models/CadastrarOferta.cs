using System.ComponentModel.DataAnnotations;

namespace DreamsViagens.Models
{
	public class CadastrarOferta
	{
		[Key]
		public int Id { get; set; }
		public string NomeDestino { get; set; }
		public string Preco { get; set; }

	}
}
