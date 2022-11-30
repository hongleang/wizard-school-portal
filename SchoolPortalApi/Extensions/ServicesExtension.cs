using SchoolPortalApi.Core.Configurations;
using SchoolPortalApi.Core.Interfaces.IRepositories;
using SchoolPortalApi.Core.Repository;
using SchoolPortalAPI.Data;
using Microsoft.EntityFrameworkCore;
using SchoolPortalApi.Core.Interfaces.IAauthManager;
using SchoolPortalApi.Core.Interfaces;
using SchoolPortalApi.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolPortalApi.Data.Entities;
using System.Text;
using Microsoft.OpenApi.Models;

namespace SchoolPortalAPI.Extensions
{
    public static class ServicesExtension
    {
        public static void AddConfigureService(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "SchoolPortalApi",
                    Version = "v1"
                });
            });

            services.AddCors();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DbConnectionString"));
            });

            AuthenticationService(services, config);

            services.AddAutoMapper(typeof(MapperProfiles));

            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IAuthManager, AuthMangerRepository>();
            services.AddScoped<ITokenServices, TokenService>();
        }

        private static void AuthenticationService(IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                   .AddEntityFrameworkStores<DataContext>()
                   .AddDefaultTokenProviders();

            /*
             * For Configure ASP.NET Core Identity see 
                https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-7.0
            */

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
            });

            /*Authorization service*/
            services.AddAuthorization();

            /*JwtBearer Authentication services*/
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
        }
    }
}
