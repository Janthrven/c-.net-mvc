using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //ConfigureServices函数的参数 IServiceCollection services对象就是对IoC容器进行操作（服务注册）的对象，可以通过它在容器中对服务进行注册
        public void ConfigureServices(IServiceCollection services)
        {
            //.netcore中，注入服务的生命周期分为三种 Transient、Scoped、Singleton
            // Transient(瞬时的)
            //每次请求时都会创建的瞬时生命周期服务。这个生命周期最适合轻量级，无状态的服务。
            //(每次都进行实例化)
            //Scoped(作用域的)
            //在同作用域,服务每个请求只创建一次。
            //(从请求开始就创建，请求结束就销毁)
            //Singleton(唯一的)
            //全局只创建一次,第一次被请求的时候被创建,然后就一直使用这一个.
            //(相当于单例)
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //代码配置数据库链接串，Mvc程序集名
            var connection = Configuration.GetConnectionString("SqlServer");
            services.AddDbContext<Mvc.Models.ApplicationDbContext>(options =>
            options.UseSqlServer(connection, b => b.MigrationsAssembly("Mvc")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
