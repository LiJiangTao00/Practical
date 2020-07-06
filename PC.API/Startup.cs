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
using PC.IDAL.Activity;
using PC.DAL.Activity;
using PC.IBLL.Activity;
using PC.BLL.Activity;
using PC.IDAL.UserIDAL;
using PC.DAL.UserDAL;
using PC.IBLL.UserIBLL;
using PC.BLL.UserBLL;
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
            services.AddSingleton<IActivityDal, ActivityDal>();
            services.AddSingleton<IUDAL,UDAL>();
            services.AddSingleton<IUBLL, UBLL>();
            services.AddSingleton<IActivityBll, ActivityBll>();
            services.AddSingleton<IConferenceDal, ConferenceDal>();
            services.AddSingleton<IConferenceBll, ConferenceBll>();
            services.AddSingleton<IUDAL, UDAL>();
            services.AddSingleton<IUBLL, UBLL>();
            services.AddCors(builder =>
            {
                builder.AddPolicy("cors", p =>
                {
                    p.WithOrigins("http://localhost:49764", "http://localhost:53518", "http://49.234.34.192:8034", "http://49.234.34.192:8035")
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            //services.AddCors(options => options.AddPolicy("cors", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

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
            //¶ÁÈ¡ÕÕÆ¬
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
