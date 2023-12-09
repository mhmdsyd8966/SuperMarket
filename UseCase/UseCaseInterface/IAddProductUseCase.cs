using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.UseCaseInterface
{
	public interface IAddProductUseCase
	{
		public void Execute(Product product);
	}
}
