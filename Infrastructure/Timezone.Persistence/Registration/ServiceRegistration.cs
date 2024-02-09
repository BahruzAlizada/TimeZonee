using Microsoft.Extensions.DependencyInjection;
using Timezone.Application.Abstract;
using Timezone.Persistence.EntityFramework;

namespace Timezone.Persistence.Registration
{
	public static class ServiceRegistration
	{
		public static void AddPersistencesServices(this IServiceCollection services)
		{
			services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
			services.AddScoped<ICategoryWriteRepository,CategoryWriteRepository>();

			services.AddScoped<IGenderReadRepository,GenderReadRepository>();
			services.AddScoped<IGenderWriteRepository,GenderWriteRepository>();

			services.AddScoped<IProductReadRepository,ProductReadRepository>();
			services.AddScoped<IProductWriteRepository,ProductWriteRepository>();

			services.AddScoped<IFaqReadRepository, FaqReadRepository>();
			services.AddScoped<IFaqWriteRepository, FaqWriteRepository>();

			services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
			services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();

			services.AddScoped<IAboutReadRepository, AboutReadRepository>();
			services.AddScoped<IAboutWriteRepository,AboutWriteRepository>();

			services.AddScoped<ISliderReadRepository,SliderReadRepository>();
			services.AddScoped<ISliderWriteRepository, SliderWriteRepository>();

			services.AddScoped<IContactReadRepository, ContactReadRepository>();
			services.AddScoped<IContactWriteRepository, ContactWriteRepository>();

			services.AddScoped<ISubscribeReadRepository, SubscribeReadRepository>();
			services.AddScoped<ISubscribeWriteRepository, SubscribeWriteRepository>();
		}
	}
} 