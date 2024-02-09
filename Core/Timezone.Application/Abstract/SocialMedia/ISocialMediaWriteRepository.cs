using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface ISocialMediaWriteRepository : IWriteRepository<SocialMedia>
	{
		void Activity(SocialMedia socialMedia);
	}
}
