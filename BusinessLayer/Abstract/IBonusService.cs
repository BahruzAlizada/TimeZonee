using EntityLayer.Concrete;
using System;


namespace BusinessLayer.Abstract
{
    public interface IBonusService
    {
        Task PlusBonus(int userId, double amount);
        Task MinusBonus(int userId, double amount);
        Task<Bonus> GetBonusUser(int userId);
        Task<double> GetBonusAmountUser(int userId);
        Task CreateBonus(int userID, double amount);

    }
}
