using Microsoft.EntityFrameworkCore;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class GenderReadRepository : ReadRepository<Gender>, IGenderReadRepository
	{
		public async Task<List<Gender>> GetActiveGendersAsync()
		{
			using var context = new Context();

			List<Gender> genders = await context.Genders.Where(x => x.Status).ToListAsync();
			return genders;
		}
	}
}
