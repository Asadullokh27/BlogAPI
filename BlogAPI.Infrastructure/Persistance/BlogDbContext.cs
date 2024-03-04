using BlogAPI.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Persistance
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) 
            : base(options) 
        {
            Database.Migrate();
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>()
                .HasMany(x => x.Permissions)
                .WithMany(x => x.Roles)
                .UsingEntity<RolePermission>();


            modelBuilder.Entity<BlogPost>()
                .HasOne(b => b.User)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(b => b.UserId);


            modelBuilder.Entity<Comment>()
                .HasOne(y => y.BlogPost)
                .WithMany(z => z.Comments)
                .HasForeignKey(y => y.BlogPostId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
