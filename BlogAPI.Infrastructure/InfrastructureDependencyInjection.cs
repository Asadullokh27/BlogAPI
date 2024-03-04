using BlogAPI.Application.Abstractions;
using BlogAPI.Infrastructure.Persistance;
using BlogAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {

        public static IServiceCollection AddInfraStruct(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BlogDbContext>(ops =>
            {
                ops.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            return services;
        }

    }
}
