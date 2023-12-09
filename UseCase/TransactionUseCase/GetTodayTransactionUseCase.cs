using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;
using UseCase.UseCaseInterface;

namespace UseCase.TransactionUseCase
{
    public class GetTodayTransactionUseCase:IGetTodayTransactionUseCase
    {
        private readonly ITransactionRepository _transatctionRepository;
        public GetTodayTransactionUseCase(ITransactionRepository transatctionRepository)
        {
            _transatctionRepository = transatctionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return _transatctionRepository.GetByDay(cashierName,DateTime.Now);
        }
    }
}
