

using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class SocialMediaWriteRepository : WriteRepository<SocialMedia>, ISocialMediaWriteRepository
	{
		public void Activity(SocialMedia socialMedia)
		{
			using var context = new Context();

			if (socialMedia.Status)
				socialMedia.Status = false;
			else
				socialMedia.Status = true;

			context.SaveChanges();
		}
	}
}
