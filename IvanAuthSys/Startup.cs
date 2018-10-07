using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityModel;
using IvanAuthSys.Data;
using IvanAuthSys.Dev;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IvanAuthSys
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.Authority = "https://oidc.faasx.com/";
                o.Audience = "api";
                o.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Query["access_token"];
                        return Task.CompletedTask;
                    }
                };

                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,

                    // 用于适配本地模拟Token
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Consts.Secret))
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            builder.RegisterType<UserStore>().AsSelf().SingleInstance();
            builder.Populate(services);

            //拉式扫描
            //Scan Register 扫描注册 每个模块内部有对应模块的注册方法
            var ph = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ModuleLib");

            var files = new DirectoryInfo(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ModuleLib")).GetFiles("*.dll");
            if (files != null && files.Length > 0)
            {
                foreach (var item in files)
                {
                    builder.RegisterAssemblyModules(Assembly.LoadFile(item.FullName));
                }
            }
            ApplicationContainer = builder.Build();
            var log = ApplicationContainer.ResolveKeyed<IvanAuthSys.Interface.ILogger>("nlog");
            Console.WriteLine(1233123);
            log.Info("123456456456456456456456456456wjh");
            return new AutofacServiceProvider(this.ApplicationContainer);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
