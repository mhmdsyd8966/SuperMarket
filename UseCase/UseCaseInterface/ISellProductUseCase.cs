using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.UseCaseInterface
{
	public interface ISellProductUseCase
	{
		public void Execute(string CashierName,int productId, int qtyToSell);
	}
}
