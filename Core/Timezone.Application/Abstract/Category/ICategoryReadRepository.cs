using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface ICategoryReadRepository : IReadRepository<Category>
	{
		Task<List<Category>> GetActiveCategoriesAsync();
	}
}
