using Timezone.Application.Abstract;
using Timezone.Domain.Entities;
using Timezone.Persistence.Repositories;

namespace Timezone.Persistence.EntityFramework
{
	internal class SliderWriteRepository : WriteRepository<Slider>,ISliderWriteRepository
	{
	}
}
