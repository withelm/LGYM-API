using Lgym.Services;
using Lgym.Services.Configurations;
using Lgym.Services.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Lgym.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim("IsAdmin", "true"));
            });


            builder.Services.InitializeMain(builder.Configuration);

            AddJwt(builder, builder.Configuration);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContex = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContex.Database.Migrate();
            }



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.MapControllers();

            app.Run();
        }

        private static void AddJwt(WebApplicationBuilder builder, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("JwtSettings");
            var jwtSettings = jwtSection.Get<JwtSettings>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // Wczytujemy klucz symetryczny (SecretKey z appsettings)
                var secretKeyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                    ValidateIssuer = false,           // Mo�na w��czy�/wy��czy� w zale�no�ci od potrzeb
                    ValidateAudience = false,         // Mo�na w��czy�/wy��czy� w zale�no�ci od potrzeb
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero        // Nie dodawaj dodatkowego buforu wa�no�ci
                };
            });

        }
    }
}
