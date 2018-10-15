using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Rookey.Frame.AutoProcess;
using Rookey.Frame.Base;
using Rookey.Frame.Controllers.AppConfig;
using Rookey.Frame.Controllers.AutoHandle;
using Rookey.Frame.Controllers.Other;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Rookey.FrameCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DI.SetConfiguration(configuration);
            //启动自动处理程序
            AutoProcessTask.EventAfterExecute += new EventHandler(SysAutoHandle.SysBackgroundTaskAdd);
            AutoProcessTask.Execute();
            //用户扩展对象
            UserExtendEventHandler.BindUserExtendEvent += new UserExtendEventHandler.EventUserExtend(UserExtendHandle.GetUserExtendObject);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                FilterConfig.RegisterGlobalFilters(options.Filters); //注册全局过滤
            }).AddJsonOptions(op => op.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new MyViewEngine()); //注册自定义视图
            });
            //开启Session服务
            services.AddSession();
            //cookie认证
            services.AddAuthentication(FormsPrincipal.COOKIE_NAME).AddCookie(FormsPrincipal.COOKIE_NAME, options =>
            {
                options.LoginPath = new PathString("/User/Login.html");
                options.AccessDeniedPath = new PathString("/User/Login.html");
                options.LogoutPath = new PathString("/User/Logout.html");
                options.Cookie.Path = "/";
                options.Cookie.Name = FormsPrincipal.COOKIE_NAME;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //异常信息页处理
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //全局配置
            app.UseWkMvcDI();
            //静态资源
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(env.ContentRootPath),
                RequestPath = new PathString(string.Empty)
            });
            //跨域处理
            app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            //开启目录浏览
            app.UseDirectoryBrowser();
            //session
            app.UseSession();
            //mvc注册路由
            app.UseMvc(routes =>
            {
                RouteConfig.RegisterRoutes(routes, app.ApplicationServices); //注册路由
            });
            //加载程序集
            TryLoadAssembly();
            //自定义应用程序启动
            SysApplicationHandle.Application_Start();
        }

        /// <summary>
        /// 加载系统程序集
        /// </summary>
        private static void TryLoadAssembly()
        {
            Assembly entry = Assembly.GetEntryAssembly();
            //找到当前执行文件所在路径
            string dir = Path.GetDirectoryName(entry.Location);
            string entryName = entry.GetName().Name;
            //获取执行文件同一目录下的其他dll
            foreach (string dll in Directory.GetFiles(dir, "*.dll"))
            {
                if (entryName.Equals(Path.GetFileNameWithoutExtension(dll)))
                    continue;
                //非程序集类型的关联load时会报错
                try
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
                }
                catch
                { }
            }
        }
    }
}
