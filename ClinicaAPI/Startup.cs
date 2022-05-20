using Domain.Context;
using Domain.Entites;
using Infra;
using Infra.Interface;
using Infra.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Service.Interface;
using Service.Service;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaAPI
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
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1",
                        Title = "API Clinica",
                        Description = "Swagger API Clinica versão 1",
                    });
                });
            });


            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services.AddIdentity<Usuario, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                            .AddEntityFrameworkStores<Context>();
            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);
            services.AddScoped(typeof(IBaseRespository<>), typeof(BaseRepository<>));
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                ClockSkew = TimeSpan.Zero
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
