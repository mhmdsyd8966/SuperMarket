using CoreBusiness;
using RepositorySQL;
using UseCase.Interface;
namespace Services

{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly MarketContext db;
		public CategoryRepository(MarketContext db)
		{
			this.db = db;
		}
		public void AddCategory(Category category)
		{
			db.Categories.Add(category);
			db.SaveChanges();
		}

		public void DeleteCategory(int catId)
		{
			var category = db.Categories.FirstOrDefault(x=>x.CategoryId == catId);
			db.Categories.Remove(category);
			db.SaveChanges();
		}

		public void EditCategory(Category category)
		{
			var cat = db.Categories.FirstOrDefault(x=>x.CategoryId==category.CategoryId);
			cat.Name= category.Name;
			cat.Description= category.Description;
			db.SaveChanges();
		}

		public IEnumerable<Category> GetCategories()
		{
			return db.Categories.ToList();
		}

		public Category GetCategoryById(int catId)
		{
			return db.Categories.Find(catId);
		}
	}
}
