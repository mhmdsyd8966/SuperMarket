﻿using CoreBusiness;
using UseCase.Interface;
using UseCase.UseCaseInterface;

namespace UseCase
{
    public class ViewCategoriesUseCase:IViewCategoriesUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> Execute()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
