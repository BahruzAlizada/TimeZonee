using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BusinessLayer.Container
{
    public static class IdentityExtension
    {
        public static void IdentityOptions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(Identityoptions =>
            {
                Identityoptions.User.RequireUniqueEmail = true;
                Identityoptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                Identityoptions.Password.RequiredLength = 8;
                Identityoptions.Password.RequireNonAlphanumeric = false;
                Identityoptions.Lockout.AllowedForNewUsers = true;
                Identityoptions.Lockout.MaxFailedAccessAttempts = 5;
                Identityoptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            }).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

        }
    }
}
