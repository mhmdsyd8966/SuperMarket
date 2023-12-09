using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Interface
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public void AddCategory(Category category);
		public void EditCategory(Category category);
		public Category GetCategoryById(int catId);
		public void DeleteCategory(int catId);
	}
}
