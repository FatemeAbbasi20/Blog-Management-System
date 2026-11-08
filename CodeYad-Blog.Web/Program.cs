using System;
using CodeYad_Blog_DataLayer.Context;
using CodeYad_Blog_CoreLayer.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using CodeYad_Blog_CoreLayer.Services.Categories;
using CodeYad_Blog_CoreLayer.Services.Posts;
using CodeYad_Blog_CoreLayer.Services.FileManager;
using CodeYad_Blog_CoreLayer.Services.Comments;
using CodeYad_Blog_CoreLayer.Services;


        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        services.AddRazorPages()
                     . AddRazorRuntimeCompilation();
        services.AddAuthorization(option => {
                        option.AddPolicy("AdminPolicy", builder => {
                            builder.RequireRole("Admin");
                    });
                    });
services.AddControllersWithViews();
services.AddScoped<IUserService, UserService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddTransient<IPostService, PostService>();
services.AddTransient<IFileManager, FileManager>();
services.AddTransient<ICommentService, CommentService>();
services.AddTransient<IMainPageService, MainPageService>();
services.AddScoped<IUserService, UserService>();

services.AddDbContext<BlogContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(Options =>
{
    Options.LoginPath = "/Auth/Login";
    Options.LogoutPath = "/Auth/Logout";
    Options.ExpireTimeSpan = TimeSpan.FromDays(30);
    Options.AccessDeniedPath = "/";
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BlogContext>();
    context.Database.Migrate();
}

if (!builder.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ErrorHandler/500");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorHandler/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(

    name: "Default", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);
   
    app.MapRazorPages();
app.Run();






















