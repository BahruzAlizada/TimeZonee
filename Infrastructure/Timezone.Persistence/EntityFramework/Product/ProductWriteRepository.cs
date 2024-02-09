using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
	{
		public void Activity(Product product)
		{
			using var context = new Context();

			if (product.Status)
				product.Status = false;
			else
				product.Status = true;

			context.SaveChanges();
		}
	}
}
