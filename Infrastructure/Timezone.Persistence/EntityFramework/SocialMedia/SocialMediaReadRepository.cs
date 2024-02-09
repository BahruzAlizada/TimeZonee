using Microsoft.EntityFrameworkCore;
using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Concrete;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class SocialMediaReadRepository : ReadRepository<SocialMedia>, ISocialMediaReadRepository
	{
		public async Task<List<SocialMedia>> GetActiveSocialMediaAsync()
		{
			using var context = new Context();

			List<SocialMedia> socialMedias = await context.socialMedias.Where(x => x.Status).ToListAsync();
			return socialMedias;
		}
	}
}
