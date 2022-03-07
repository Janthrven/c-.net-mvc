using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc
{
    //程序入口
    public class Program
    {
        //该方法是一个静态方法，参数args可以在通过控制台启动它时传入
        //常见的args参数使用方法：如程序在开发环境和生产环境（实际使用的环境）需要读取不同的配置文件，我们就可以
        //规定args的第一个参数如果为"dev"则读取开发环境使用的配置appsettings.dev.json 	   
        //如果为"prod" 则使用正式的appsettings.json配置文件。
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        //配置服务器,net core中内置了一个Kestrel服务器，该服务器是一个基于libuv的跨平台ASP.NET Core web服务器，libuv是一个跨平台的异步I/O库
        //ASP.NET Core模板项目使用Kestrel作为默认的web服务器
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
