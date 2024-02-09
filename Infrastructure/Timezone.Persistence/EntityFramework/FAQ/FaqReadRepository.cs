using Microsoft.EntityFrameworkCore;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class FaqReadRepository : ReadRepository<Faq>, IFaqReadRepository
	{
		public async Task<List<Faq>> GetActiveFaqsAsync()
		{
			using var context = new Context();

			List<Faq> faqs = await context.Faqs.Where(x => x.Status).ToListAsync();
			return faqs;
		}
	}
}
