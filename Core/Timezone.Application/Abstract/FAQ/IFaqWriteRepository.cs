using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface IFaqWriteRepository : IWriteRepository<Faq>
	{
		void Activity(Faq faq);
	}
}
