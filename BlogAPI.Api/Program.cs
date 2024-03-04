using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using BlogAPI.Infrastructure;
using BlogAPI.Application;


namespace BlogAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfraStruct(builder.Configuration);
            builder.Services.AddAppServices();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Future Projects", Version = "v1.0.0", Description = "Future Projects Auth API" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };
                c.AddSecurityRequirement(securityRequirement);
            });
            //something
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                           .AddJwtBearer(
                               options =>
                               {
                                   options.TokenValidationParameters = GetTokenValidationParameters(builder.Configuration);

                                   options.Events = new JwtBearerEvents
                                   {
                                       OnAuthenticationFailed = (context) =>
                                       {
                                           if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                           {
                                               context.Response.Headers.Add("IsTokenExpired", "true");
                                           }
                                           return Task.CompletedTask;
                                       }
                                   };
                               });

            builder.Services.AddAuthorization();

            // Add controllers services
            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:ValidIssuer"],
                ValidAudience = configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                ClockSkew = TimeSpan.Zero,
            };
        }
    }
}
