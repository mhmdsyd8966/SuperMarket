using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Interface
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetProducts();
		public void AddProduct(Product product);
		public void UpdateProduct(Product product);
		Product GetProductById(int id);
		public void DeleteProduct(int id);
		IEnumerable<Product> GetProductsByCategoryId(int catId);
	}
}
