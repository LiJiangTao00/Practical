using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PC.IDAL.IMaterialDAL;
using PC.DAL.MaterialDal;
using PC.IBLL.MaterialBLL;
using PC.BLL.MaterialBll;
using PC.IDAL.Conference;
using PC.DAL.Conference;
using PC.IBLL.Conferences;
using PC.BLL.Conferences;
using PC.IBLL.UserIBLL;
using PC.IDAL.UserIDAL;
using PC.BLL.UserBLL;
using PC.DAL.UserDAL;

namespace PC.API
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
            services.AddSingleton<IMaterialDAL, MaterialDAL>();
            services.AddSingleton<IMaterialBLL,MaterialBLL>();

            services.AddSingleton<IConferenceDal, ConferenceDal>();
            services.AddSingleton<IConferenceBll, ConferenceBll>();
            services.AddSingleton<IUBLL, UBLL>();
            services.AddSingleton<IUDAL, UDAL>();
            services.AddCors(options => options.AddPolicy("cors", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("cors");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
