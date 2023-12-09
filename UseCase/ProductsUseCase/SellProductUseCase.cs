using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;
using UseCase.TransactionUseCase;
using UseCase.UseCaseInterface;

namespace UseCase.ProductsUseCase
{
	public class SellProductUseCase:ISellProductUseCase
	{
		private readonly IProductRepository _productRepository;
		public readonly IRecorTransactionUseCase _recorTransactionUseCase;
		public SellProductUseCase(IProductRepository productRepository , IRecorTransactionUseCase recorTransactionUseCase)
		{
			_productRepository = productRepository;
			_recorTransactionUseCase = recorTransactionUseCase;
		}
		public void Execute(string cashierName, int productId, int qtyToSell)
		{
			var product = _productRepository.GetProductById(productId);
			if (product == null) return;

			_recorTransactionUseCase.Execute(cashierName, productId, qtyToSell);
			product.Quantity -= qtyToSell;
			_productRepository.UpdateProduct(product);
		}
	}
}
