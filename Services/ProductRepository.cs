using CoreBusiness;
using RepositorySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;

namespace Services
{
	public class ProductRepository : IProductRepository
	{
		private readonly MarketContext db;
		public ProductRepository(MarketContext db)
		{
			this.db = db;
		}
		public void AddProduct(Product product)
		{
			db.Products.Add(product);
			db.SaveChanges();
		}

		public void DeleteProduct(int id)
		{
			var product = db.Products.FirstOrDefault(x=>x.ProductId== id);
			if (product == null)
				return;
			db.Products.Remove(product);
			db.SaveChanges();
		}

		public Product GetProductById(int id)
		{
			return db.Products.Find(id);
		}

		public IEnumerable<Product> GetProducts()
		{
			return db.Products.ToList();
		}

		public IEnumerable<Product> GetProductsByCategoryId(int catId)
		{
			return db.Products.Where(x=>x.CategoryId==catId).ToList();
		}

		public void UpdateProduct(Product product)
		{
			var prod = db.Products.Find(product.ProductId);
			prod.CategoryId = product.CategoryId;
			prod.Name=product.Name;
			prod.Price = product.Price;
			prod.Quantity=product.Quantity;
			db.SaveChanges();
		}
	}
}
