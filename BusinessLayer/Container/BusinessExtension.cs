using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace BusinessLayer.Container
{
    public static class BusinessExtension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EFAboutDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal,EFContactDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EFSliderDal>();

            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

            services.AddScoped<INewsletterService, NewsletterManager>();
            services.AddScoped<INewsletterDal, EFNewsletterDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EFProductDal>();



            services.AddScoped<IBonusService, BonusManager>();
            services.AddScoped<IBonusDal, EFBonusDal>();

            services.AddScoped<IFaqService, FaqManager>();
            services.AddScoped<IFaqDal, EFFaqDal>();

            services.AddScoped<IBioService, BioManager>();
            services.AddScoped<IBioDal,EFBioDal>();

            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddScoped<IVacancyDal, EFVacancyDal>();

        }

    }
}
