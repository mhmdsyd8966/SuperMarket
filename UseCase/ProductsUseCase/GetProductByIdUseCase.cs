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
	public class GetProductByIdUseCase:IGetProductByIdUseCase
	{
		private readonly IProductRepository _productRepository;
		public GetProductByIdUseCase(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public Product Execute(int ProductId)
		{
			return _productRepository.GetProductById(ProductId);
		}
	}
}
