using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using SmartParkingPermit.Core.Interfaces;
using SmartParkingPermit.Core.Services;
using SmartParkingPermit.Core.Models.DB;
using AutoMapper;
using SmartParkingPermit.Core.AutoMapperProfile;
using FluentValidation.AspNetCore;
using FluentValidation;
using SmartParkingPermit.Core.Models;

namespace SmartParkingPermit.Core
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
            // Add TicketSearchContext services.  
            services.AddDbContext<ParkingPermitContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ParkingPermitDBConn")));
            services.AddScoped<IParkingPermitServiceDAL, ParkingPermitServiceDAL>();
            services.AddScoped<IParkingPermitServiceBAL, ParkingPermitServiceBAL>();
            services.AddSingleton(Configuration);

            // Enable CORS  // To Do 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAnyOrigin"));
            });

            //Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
            services.AddAutoMapper(typeof(ParkingProfile));



            services.AddMvc();
            services.AddMvc(setup =>
            {
                //...mvc setup...
            }).AddFluentValidation();

            //services.AddTransient<IValidator<ParkingPermitResquestModel>, ParkingPermitResquestModelValidator>();
            //services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ParkingPermitResquestModelValidator>());

            services.AddCors();
            services.AddMvc().AddJsonOptions(options =>
            {
                if (options.SerializerSettings.ContractResolver != null)
                {
                    var resolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                    resolver.NamingStrategy = null;
                }
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // Add controllers as services so they'll be resolved.
            services.AddMvc().AddControllersAsServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("AllowAnyOrigin");
        }
    }
}
