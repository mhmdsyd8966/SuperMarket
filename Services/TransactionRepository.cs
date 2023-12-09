using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using RepositorySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Interface;

namespace Services
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly MarketContext db;
		public TransactionRepository(MarketContext db)
		{
			this.db = db;
		}
		public IEnumerable<Transaction> Get(string cashierName)
		{
			return db.Transactions.Where(x=>x.CashierName== cashierName).ToList();	
		}

		public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
		{
			if (string.IsNullOrEmpty(cashierName))
				return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
			else
				return db.Transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
				x.TimeStamp.Date == date.Date);
		}

		public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
		{
			var Transaction = new Transaction
			{
				ProductId = productId,
				ProductName=productName,
				TimeStamp = DateTime.Now,
				Price = price,
				BeforeQty = beforeQty,
				SoldQty = soldQty,
				CashierName = cashierName

			};
			db.Transactions.Add(Transaction);
			db.SaveChanges();
		}

		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime dateTime)
		{
			if(string.IsNullOrEmpty(cashierName))
				return db.Transactions.Where(x=>x.TimeStamp>=startDate.Date&&x.TimeStamp<=dateTime.Date.AddDays(1).Date);
			else
				return db.Transactions.Where(x => EF.Functions.Like(x.CashierName,$"%{cashierName}%")&&
				x.TimeStamp >= startDate.Date && x.TimeStamp <= dateTime.Date.AddDays(1).Date);
		}
	}
}
