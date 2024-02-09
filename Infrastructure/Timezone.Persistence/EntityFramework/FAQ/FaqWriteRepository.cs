using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class FaqWriteRepository : WriteRepository<Faq>, IFaqWriteRepository
	{
		public void Activity(Faq faq)
		{
			using var context = new Context();

			if (faq.Status)
				faq.Status = false;
			else
				faq.Status = true;

			context.SaveChanges();
		}
	}
}
