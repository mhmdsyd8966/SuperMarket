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
	public class ViewProductsUseCase:IViewProductUseCase
	{
		private readonly IProductRepository _productRepository;
		public ViewProductsUseCase(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public IEnumerable<Product> Execute()
		{
			return _productRepository.GetProducts();
		}
	}
}
