using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;
using CoreBusiness;
using UseCase.UseCaseInterface;


namespace UseCase.TransactionUseCase
{
    public class GetTransactionUseCase:IGetTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        public GetTransactionUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName,DateTime startDate,DateTime endDate)
        {
            return _transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
