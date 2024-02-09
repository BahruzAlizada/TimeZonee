using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IBonusDal : IRepositoryBase<Bonus>
    {
        Task CreateBonus(int userID,double amount);
        Task PlusBonus(int userId, double amount);
        Task MinusBonus(int userId, double amount);
        Task<Bonus> GetBonusUser(int userId);
        Task<double> GetBonusAmountUser(int userId);
    }
}
