using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface IProductWriteRepository : IWriteRepository<Product>
	{
		void Activity(Product product);
	}
}
