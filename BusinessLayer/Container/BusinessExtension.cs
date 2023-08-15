using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
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

            services.AddScoped<IContactInfoService,ContactInfoManager>();
            services.AddScoped<IContactInfoDal, EFContactInfoDal>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal,EFBlogDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EFSliderDal>();

            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EFSocialMediaDal>();

            services.AddScoped<IGaleryService, GaleryManager>();
            services.AddScoped<IGaleryDal, EFGaleryDal>();

            services.AddScoped<INewsletterService, NewsletterManager>();
            services.AddScoped<INewsletterDal, EFNewsletterDal>();
        }

    }
}
