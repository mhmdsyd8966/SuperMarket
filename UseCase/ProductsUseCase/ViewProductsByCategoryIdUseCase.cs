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
	public class ViewProductsByCategoryIdUseCase:IViewProductsByCategoryIdUseCase
	{
		private readonly IProductRepository _productRepository;
		public ViewProductsByCategoryIdUseCase(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public IEnumerable<Product> Execute(int catId)
		{
			return _productRepository.GetProductsByCategoryId(catId);
		}
	}
}
