using API.DataAccess;
using API.Interfaces.Access;
using API.Interfaces.Advertisements;
using API.Interfaces.Companies;
using API.Interfaces.Companies.Jobs;
using API.Interfaces.Companies.Jobs.AdditionalInfo;
using API.Interfaces.Culture.Events;
using API.Interfaces.Culture.Posts;
using API.Interfaces.Users;
using API.Interfaces.Users.AdditionalInfo;
using API.Interfaces.Users.Resumes;
using API.Repositories.Access;
using API.Repositories.Advertisements;
using API.Repositories.Companies;
using API.Repositories.Companies.Job.AdditionalInfo;
using API.Repositories.Companies.Jobs;
using API.Repositories.Companies.Jobs.AdditionalInfo;
using API.Repositories.Culture.Events;
using API.Repositories.Culture.Posts;
using API.Repositories.Users;
using API.Repositories.Users.AdditionalInfo;
using API.Repositories.Users.Resumes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
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

            services.AddDbContext<ToDentroContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Oficial"));
            });

            // Initial access
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IRegisterRepository, RegisterRepository>();

            // Advertisements
            services.AddTransient<IAdvertisementRepository, AdvertisementRepository>();

            // Cultural space
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            // Company
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<IRequirementRepository, RequirementRepository>();
            services.AddTransient<IDifferentialRepository, DifferentialRepository>();
            services.AddTransient<IJobManagementRepository, JobManagementRepository>();

            // User
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IResumeRepository, ResumeRepository>();
            services.AddTransient<IExperienceRepository, ExperienceRepository>();
            services.AddTransient<IEducationRepository, EducationRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();

            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                    };
                });

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });


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
