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
	
	
	public class GetCategoryByIdUseCase:IGetCategoryByIdUseCase
	{
		private readonly ICategoryRepository _categoryRepository;
		public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public Category Execute(int catId)
		{
			return _categoryRepository.GetCategoryById(catId);
		}
	}
}
