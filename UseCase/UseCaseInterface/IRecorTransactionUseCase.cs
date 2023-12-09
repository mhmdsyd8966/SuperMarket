using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.UseCaseInterface
{
    public interface IRecorTransactionUseCase
    {
        public void Execute(string cashierName, int productId, int qty);
    }
}
