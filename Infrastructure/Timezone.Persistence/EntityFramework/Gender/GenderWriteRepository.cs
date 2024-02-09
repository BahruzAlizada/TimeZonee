using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class GenderWriteRepository : WriteRepository<Gender>, IGenderWriteRepository
	{
        public void Activity(Gender gender)
		{
			using var context = new Context();
			if (gender.Status)
				gender.Status = false;
			else
				gender.Status = true;

			context.SaveChangesAsync();
		}
	}
}
