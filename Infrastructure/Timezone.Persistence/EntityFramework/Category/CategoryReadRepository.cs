using Microsoft.EntityFrameworkCore;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
	{
		public async Task<List<Category>> GetActiveCategoriesAsync()
		{
			using var context = new Context();

			List<Category> categories = await context.Categories.Where(x => x.Status).ToListAsync();
			return categories;
		}
	}
}
