using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity; 
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using Timezone.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ContainerDependencies();

builder.Services.AddSignalR();


builder.Services.AddMemoryCache();

builder.Services.AddStackExchangeRedisCache(options => options.Configuration = "localhost:2000");

builder.Services.AddLogging(log =>
{
    log.ClearProviders();
    log.SetMinimumLevel(LogLevel.Information);
    log.AddConsole();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(orign => true);
    });
});

builder.Services.AddDbContext<Context>();

builder.Services.IdentityOptions();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseStaticFiles();
app.MapHub<ChatHub>("/chathub");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");

app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Profile}/{action=Index}/{id?}");
app.MapControllerRoute(
    
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
