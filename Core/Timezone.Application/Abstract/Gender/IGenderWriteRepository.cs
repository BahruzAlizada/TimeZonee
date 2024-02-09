using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface IGenderWriteRepository : IWriteRepository<Gender>
	{
		void Activity(Gender gender);
	}
}
