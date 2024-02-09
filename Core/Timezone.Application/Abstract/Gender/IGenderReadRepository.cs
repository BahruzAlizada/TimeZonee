using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface IGenderReadRepository : IReadRepository<Gender>
	{
		Task<List<Gender>> GetActiveGendersAsync();
	}
}
