using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface IFaqReadRepository : IReadRepository<Faq>
	{
		Task<List<Faq>> GetActiveFaqsAsync();
	}
}
