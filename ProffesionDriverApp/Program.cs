using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProfessionDriverApp.Domain.Models;
using ProfessionDriverApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddDbContext<ProfessionDriverProjectContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("ProfessionDriverDb")), ServiceLifetime.Scoped);

        //Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
            xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

            //Swagger JWT
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Please enter only '[jwt]'",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Name = "Authorization",
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id=JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
        });

        //DI
        ProfessionDriverApp.Application.Configurations.Dependencies.Register(builder.Services);

        //JWT
        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
               .AddEntityFrameworkStores<ProfessionDriverProjectContext>()
               .AddDefaultTokenProviders();

        var secret = builder.Configuration["JWT:Secret"] ?? throw new InvalidOperationException("Secret not configured");
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                ValidAudience = builder.Configuration["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ClockSkew = TimeSpan.FromSeconds(5),
                RoleClaimType = ClaimTypes.Role
            };
            options.Events = new JwtBearerEvents
            {
                OnChallenge = ctx => LogAttempt(ctx.Request.Headers, "OnChallenge"),
                OnTokenValidated = ctx => LogAttempt(ctx.Request.Headers, "OnTokenValidated")
            };
        });

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddHttpContextAccessor();

        // CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        app.UseCors("AllowAllOrigins");

        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);
        }



        app.UseHttpsRedirection();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }
        else
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }

        //Swagger
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            // options.RoutePrefix = string.Empty; //-> route directly to swagger
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

        //Methods
        Task LogAttempt(IHeaderDictionary headers, string eventType)
        {
            //var logger = loggerFactory.CreateLogger<Program>();

            var authorizationHeader = headers["Authorization"].FirstOrDefault();

            if (authorizationHeader is null)
            {
                // logger.LogInformation($"{eventType}. JWT not present");
            }
            else
            {
                string jwtString = authorizationHeader.Substring("Bearer ".Length);

                var jwt = new JwtSecurityToken(jwtString);

                //logger.LogInformation($"{eventType}. Expiration: {jwt.ValidTo.ToLongTimeString()}. System time: {DateTime.UtcNow.ToLongTimeString()}");
            }
            return Task.CompletedTask;
        }

        static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User", "Manager" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}