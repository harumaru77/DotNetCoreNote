﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;                        // ASP.NET Core 인증
using Microsoft.AspNetCore.Authentication.Cookies;      // ASP.NET Core 인증
using System.IO;
using DotNetNote.Services;
using DotNetNote.Settings;
using DotNetNote.Models;

namespace DotNetNote
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"Settings\\DotNetNoteSettings.json", optional: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // [!] Configuration: JSON 파일의 데이터를 POCO 클래스에 주입
            services.Configure<DotNetNoteSettings>(Configuration.GetSection("DotNetNoteSettings"));
            services.AddMvc();
            services.AddDirectoryBrowser();

            // [Demo] DataFinder 의존성 주입
            services.AddTransient<DotNetNote.Models.DataFinder>();

            // [DI] InfoService 클래스 의존성 주입
            services.AddSingleton<InfoService>();
            // [DI] IInfoService 인터페이스 의존성 주입
            services.AddSingleton<IInfoService, InfoService>();
            // [DI] CopyrightService 클래스 의존성 주입
            //services.AddTransient<CopyrightService>();
            // [DI] ICopyrightService 인터페이스 의존성 주입
            services.AddScoped<ICopyrightService, CopyrightService>();
            // [DI] @inject 키워드로 View에 직접 클래스의 속성 또는 메서드 값 출력
            services.AddSingleton<CopyrightService>();

            services.AddAuthentication("MyCookieAuthenticationScheme").AddCookie(
                "MyCookieAuthenticationScheme",
                options => {
                    options.LoginPath = "/User/Login";
                    options.AccessDeniedPath = "/User/Forbidden";
                });

            services.AddAuthorization(options => {
                // Users Role 이 있으면, Users Policy 부여
                options.AddPolicy("Users", policy => policy.RequireRole("Users"));
                // Users Role이 있고, "Admin"이면 "Administrators" 부여
                options.AddPolicy("Administrators", 
                                    policy => policy.RequireRole("Users")
                                                    .RequireClaim("UserId", Configuration
                                                                            .GetSection("DotNetNoteSettings")
                                                                            .GetSection("SiteAdmin").Value));
            });

            services.AddSingleton<IUserRepository, UserRepositoryInMemory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 다른 페이지가 실행되지 않고, 샘풀 페이지(Welcome Page)만 실행되게 한다.
            //app.UseWelcomePage();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Static Files 서비스를 위한 기본 경로 변경 코드
            /*
            app.UseStaticFiles(
                new StaticFileOptions(){
                    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles")),
                    RequestPath = new Microsoft.AspNetCore.Http.PathString("/StaticFiles")
                }
            );
            */

            // 기본 제공 문서를 원하는 파일명(NewDefault.html)으로 옵션 지정할 수 있다.
            // 기본적으로는 default.htm, default.html, index.htm, index.html 순으로 찾아서 있으면 실행된다.
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("NewDefault.html");            

            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            app.UseDirectoryBrowser();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
