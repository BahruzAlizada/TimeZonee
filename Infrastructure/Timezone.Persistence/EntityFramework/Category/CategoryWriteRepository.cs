using Timezone.Application.Abstract;
using Timezone.Application.Repositories;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public void Activity(Category category)
		{
			using var context = new Context();

			if (category.Status)
				category.Status = false;
			else
				category.Status = true;

			context.SaveChangesAsync();
		}
	}
}
