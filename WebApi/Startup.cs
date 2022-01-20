using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Repository;

namespace WebApi
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.RequireHttpsMetadata = false;
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         // укзывает, будет ли валидироваться издатель при валидации токена
                         ValidateIssuer = true,
                         // строка, представляющая издателя
                         ValidIssuer = AuthOptions.ISSUER,

                         // будет ли валидироваться потребитель токена
                         ValidateAudience = true,
                         // установка потребителя токена
                         ValidAudience = AuthOptions.AUDIENCE,
                         // будет ли валидироваться время существования
                         ValidateLifetime = true,

                         // установка ключа безопасности
                         IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                         // валидация ключа безопасности
                         ValidateIssuerSigningKey = true,
                     };
                 });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });

            services.AddMvc();

            services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<Company>, CompanyRepository>();
            services.AddScoped<IRepository<EP_Representative>, EP_RepresentativeRepository>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<StudentCompanyData>, StudentCompanyDataRepository>();
            services.AddScoped<IRepository<EducationalProgramme>, EducationalProgrammeRepository>();
            services.AddScoped<IRepository<UNI_Representative>, UNI_RepresentativeRepository>();
            services.AddScoped<IRepository<EventRequest>, EventRequestRepository>();
            services.AddScoped<IRepository<PartnershipRequest>, PartnershipRequestRepository>();
            services.AddScoped<IRepository<Response>, ResponseRepository>();
            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<IRepository<University>, UniversityRepository>();
            services.AddScoped<IRepository<Vacancy>, VacancyRepository>();
            services.AddScoped<IOAuth, OAuthRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
