using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using PengeSoft.Web;
//using Ps.TsServiceLib.Core;
using System.IO;
using System.Threading.Tasks;

namespace PYZP
{
    public static partial class MiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpServiceProxyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PengeSoft.Middleware.HttpServiceProxy>();
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //服务注册
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                                             //builder.WithOrigins("http://localhost:8080") ////允许http://localhost:8080的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie

                    });
            });

            services.AddHttpContextAccessor();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }

            //搞定刷新问题
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("pyzp.html");
            app.UseDefaultFiles(defaultFilesOptions);

            app.UseStaticFiles();
            //app.UseRouter(builder => builder.MapGet("services/{name}.sts", TsService));

            app.UseHttpServiceProxyMiddleware();
            app.UseStaticHttpContext();
            app.UseMvc();
        }

    }
}
