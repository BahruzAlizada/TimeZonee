using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface ICategoryWriteRepository : IWriteRepository<Category>
	{
		void Activity(Category category);
	}
}
