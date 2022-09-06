using FluentValidation.AspNetCore;
using FluentValidation.WebApi.Models;
using FluentValidation.WebApi.Validators;
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

namespace FluentValidation.WebApi
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

            #region Register FluentValidator services
            // Register all Validator services
            services.AddValidatorsFromAssemblyContaining<Startup>();

            // Register service one by one
            //services.AddScoped<IValidator<Tester>, TesterValidator>();
            #endregion

            #region Enable FluentValidation
            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            #region Deprecated
            //services.AddFluentValidation(config =>
            //{
            //    // Deprecated https://docs.fluentvalidation.net/en/latest/upgrading-to-11.html?highlight=RunDefaultMvcValidationAfterFluentValidationExecutes#asp-net-core-integration-changes
            //    //config.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            //});
            #endregion
            #endregion
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
