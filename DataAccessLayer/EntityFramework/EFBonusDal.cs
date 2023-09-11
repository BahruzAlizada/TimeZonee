using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFBonusDal : EfRepositoryBase<Bonus, Context>, IBonusDal
    {
        public async Task<Bonus> GetBonusUser(int userId)
        {
            using var context = new Context();
            Bonus bonus = await context.Bonuses.Include(x=>x.AppUser).Where(x=>x.AppUserId == userId).FirstOrDefaultAsync();
            return bonus;
        }

        public async Task MinusBonus(int userId,double amount)
        {
            using var context = new Context();
            Bonus bonus = await context.Bonuses.Include(x => x.AppUser).Where(x => x.AppUserId == userId).FirstOrDefaultAsync();
            bonus.Amount = bonus.Amount - amount;
        }

        public async Task PlusBonus(int userId,double amount)
        {
            using var context = new Context();
            Bonus bonus = context.Bonuses.FirstOrDefault();
            bonus.Amount = bonus.Amount + amount;
        }
    }
}
