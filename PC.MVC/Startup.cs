using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PC.BLL.Activity;
using PC.BLL.Conferences;
using PC.BLL.MaterialBll;
using PC.BLL.UserBLL;
using PC.DAL.Activity;
using PC.DAL.Conference;
using PC.DAL.MaterialDal;
using PC.DAL.UserDAL;
using PC.IBLL.Activity;
using PC.IBLL.Conferences;
using PC.IBLL.MaterialBLL;
using PC.IBLL.UserIBLL;
using PC.IDAL.Activity;
using PC.IDAL.Conference;
using PC.IDAL.IMaterialDAL;
using PC.IDAL.UserIDAL;

namespace PC.MVC
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
           
            services.AddControllersWithViews();
            services.AddSingleton<IMaterialDAL,MaterialDAL>();
            services.AddSingleton<IMaterialBLL,MaterialBLL>();
            services.AddSingleton<IUDAL, UDAL>();
            services.AddSingleton<IUBLL, UBLL>();
            services.AddSingleton<IActivityDal, ActivityDal>();
            services.AddSingleton<IActivityBll, ActivityBll>();
            services.AddSingleton<IConferenceDal, ConferenceDal>();
            services.AddSingleton<IConferenceBll, ConferenceBll>();
            //配置跨域处理，允许所有来源：
            services.AddCors(options =>
            options.AddPolicy("cor",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("cor");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Login}/{id?}");
            });
        }
    }
}
