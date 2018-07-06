using System;
using System.Collections.Generic;

namespace starkdev.spreadrecon.business
{
	public interface IImportacao<T> 
	{
		bool Importar(T importacao);
	}
}
