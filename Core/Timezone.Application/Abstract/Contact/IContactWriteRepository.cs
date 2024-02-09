﻿using Timezone.Application.Repositories;
using Timezone.Domain.Entities;

namespace Timezone.Application.Abstract
{
	public interface IContactWriteRepository : IWriteRepository<Contact>
	{
	}
}
