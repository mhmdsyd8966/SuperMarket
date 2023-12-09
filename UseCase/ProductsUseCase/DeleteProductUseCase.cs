using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;
using UseCase.UseCaseInterface;

namespace UseCase.ProductsUseCase
{
	public class DeleteProductUseCase:IDeleteProductUseCase
	{
		private readonly IProductRepository _productRepository;
		public DeleteProductUseCase(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public void Execute(int Id)
		{
			_productRepository.DeleteProduct(Id);
		}
	}
}
