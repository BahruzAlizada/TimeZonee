

using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
	public class EFBonusDal : EfRepositoryBase<Bonus, Context>, IBonusDal
	{
		public Task CreateBonus(int userID, double amount)
		{
			throw new NotImplementedException();
		}

		public Task<double> GetBonusAmountUser(int userId)
		{
			throw new NotImplementedException();
		}

		public Task<Bonus> GetBonusUser(int userId)
		{
			throw new NotImplementedException();
		}

		public Task MinusBonus(int userId, double amount)
		{
			throw new NotImplementedException();
		}

		public Task PlusBonus(int userId, double amount)
		{
			throw new NotImplementedException();
		}
	}
}
