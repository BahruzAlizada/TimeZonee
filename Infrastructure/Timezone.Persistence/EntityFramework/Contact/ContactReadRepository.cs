using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	public class ContactReadRepository : ReadRepository<Contact>,IContactReadRepository
	{
	}
}
