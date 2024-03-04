using BlogAPI.Application.Services.AuthServices;
using BlogAPI.Application.Services.BlogPostServices;
using BlogAPI.Application.Services.CommentServices;
using BlogAPI.Application.Services.Hasher;
using BlogAPI.Application.Services.PermissionServices;
using BlogAPI.Application.Services.RoleServices;
using BlogAPI.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IHasher, Hasher>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            return services;
        }

    }
}
