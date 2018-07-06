using System;
using System.Collections.Generic;

namespace starkdev.spreadrecon.business
{
	public interface ICrud<T> 
	{
		long Salvar(T obj);
		T Detalhe(long id);
		List<T> ListarTodos();
		void Excluir(int id);
	}
}
