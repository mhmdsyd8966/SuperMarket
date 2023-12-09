using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;
using UseCase.UseCaseInterface;

namespace UseCase
{
	public class DeleteCategoryUseCase:IDeleteCategoryUseCase
	{
		private readonly ICategoryRepository _categoryRepository;
		public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public void Delete(int catId) {
			_categoryRepository.DeleteCategory(catId);
		}
	}
}
