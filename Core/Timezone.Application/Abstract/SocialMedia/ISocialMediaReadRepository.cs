using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface ISocialMediaReadRepository : IReadRepository<SocialMedia>
	{
		Task<List<SocialMedia>> GetActiveSocialMediaAsync();
	}
}
