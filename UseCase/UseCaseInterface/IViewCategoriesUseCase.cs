﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.UseCaseInterface
{
    public interface IViewCategoriesUseCase
    {
		public IEnumerable<Category> Execute();

	}
}
