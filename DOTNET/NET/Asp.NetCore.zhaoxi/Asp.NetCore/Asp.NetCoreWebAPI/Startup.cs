using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Asp.NetCore.Infrastructure.Extensin;
using Autofac;
using BusinessService.Asp.netCore.AutoFac;
using BusinessService.Asp.netCore.UserBLL;
using DataAccess;
using DataAccess.Asp.netCore;
using EntityFrameworkCore.Base;
using IBusinessService.Asp.netCore.AutoFac;
using IBusinessService.Asp.netCore.UserBLL;
using IDataAccess.Asp.netCore;

namespace Asp.NetCoreWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            GloablOpretion.Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Asp.NetCoreWebAPI", Version = "v1"});
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //注册IService 和实例为Service
            builder.RegisterType<Service>().As<IService>();
            builder.RegisterType<TestDbContext>().As<TestDbContext>();
            builder.RegisterType<UserBLL>().As<IUserBLL>();

            #region 注册泛型模板

            builder.RegisterGeneric(typeof(BaseDAL<,>)).As(typeof(IBaseDAL<,>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryDAL<>)).As(typeof(IRepositoryDAL<>)).InstancePerDependency();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asp.NetCoreWebAPI v1"));
            }


            app.UseStaticFiles(new StaticFileOptions()
            {
                //指定wwwroot 路径
                // FileProvider = new PhysicalFileProvider(@"F:\Log\Code\DOTNET\NET\Core5.0.MVCDemo\wwwroot")
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
} 