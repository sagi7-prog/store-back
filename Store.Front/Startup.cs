using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Store.Business.Services;
using Store.Business.Services.Interfaces;
using Store.Data.Context;
using Store.Data.Repositories;
using Store.Data.Repositories.Interfaces;
using Store.Entities.Models;
using System.Text;
using Newtonsoft.Json;

namespace Store.Front
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            // Configurar Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Store API",
                    Version = "v1"
                });
            });

            services.AddDbContext<StoreDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("StoreSolution"))
            );

            // Repositorios y servicios
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IcustomerService, CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IGenericRepository<ClientesArticulos>, GenericRepository<ClientesArticulos>>();


            // Configuración JWT
            var key = Encoding.ASCII.GetBytes("MODULE_AUTHENTICATION_STORE_2552");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Habilitar CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocal", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Habilitar Swagger y Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API V1");
                c.RoutePrefix = string.Empty; // Esto hace que Swagger sea la página principal
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            // Activar CORS
            app.UseCors("AllowLocal");

            // Habilitar autenticación
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
