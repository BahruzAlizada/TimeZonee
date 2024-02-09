using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;

namespace BusinessLayer.Concrete
{
    public class BonusManager : IBonusService
    {
        private readonly IBonusDal bonusDal;
        public BonusManager(IBonusDal bonusDal)
        {
            this.bonusDal = bonusDal;
        }

        public async Task CreateBonus(int userID, double amount)
        {
            await bonusDal.CreateBonus(userID, amount);
        }

        public Task<double> GetBonusAmountUser(int userId)
        {
            return bonusDal.GetBonusAmountUser(userId);
        }

        public async Task<Bonus> GetBonusUser(int userId)
        {
            return await bonusDal.GetBonusUser(userId);
        }

        public async Task MinusBonus(int userId, double amount)
        {
            await bonusDal.MinusBonus(userId, amount);
        }

        public async Task PlusBonus(int userId, double amount)
        {
            await bonusDal.PlusBonus(userId, amount);
        }
    }
}
