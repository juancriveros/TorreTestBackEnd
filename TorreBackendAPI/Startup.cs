using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorreBackend.API.Models;
using TorreBackend.Business;
using TorreBackend.Entities;

namespace TorreBackendAPI
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

            services.AddAutoMapper(configuration =>
            {

                configuration.CreateMap<AgregatorValue, AggregatorSummaryModel>();
                configuration.CreateMap<OpportunityResult, SearchOpportunityResultModel>();
                configuration.CreateMap<Organization, OrganizationModel>();     
                configuration.CreateMap<Compensation, CompensationModel>();
                configuration.CreateMap<CompensationData, CompensationDataModel>();
                configuration.CreateMap<Skill, SkillModel>();

            }, typeof(Startup));


            services.AddSingleton<OpportunityBusiness>(new OpportunityBusiness(new ApiClient(new Uri("https://search.torre.co/opportunities/_search/"))));
            services.AddSingleton<UsersBusiness>(new UsersBusiness(new ApiClient(new Uri("https://search.torre.co/people/_search/"))));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
