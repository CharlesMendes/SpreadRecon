using System;
using System.ComponentModel.DataAnnotations;

namespace starkdev.spreadrecon.model
{
	public class Pessoa
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Nome da Pessoa é obrigatório")]
		public string Nome { get; set; }
	}
}
