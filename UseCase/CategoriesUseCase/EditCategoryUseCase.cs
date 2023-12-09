using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;
using UseCase.UseCaseInterface;

namespace UseCase
{
	public class EditCategoryUseCase: IEditCategoryUseCase
	{
		private readonly ICategoryRepository _categoryRepository;
		public EditCategoryUseCase(ICategoryRepository categoryRepository) { 
			_categoryRepository = categoryRepository;
		}
		public void Execute(Category category)
		{
			_categoryRepository.EditCategory(category);
		}
	}
}
