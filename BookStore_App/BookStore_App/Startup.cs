using BookStore_App.Data;
using BookStore_App.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(
                    options => options.UseSqlServer("Server=.;Database=BookStoreApp; Integrated Security=true;"));


            services.AddControllersWithViews();
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

                //Uncomment this code to disable client side validations.
                //.AddViewOptions(options =>
                //{
                //    options.HtmlHelperOptions.ClientValidationEnabled = false;
                //});

#endif
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
            //    RequestPath = "/MyStaticFiles"
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();

                //    endpoints.MapControllerRoute(
                //        name: "Default",
                //        pattern: "{controller=Home}/{action=Index}/{Id?}");
                //});

                //************** Begin - Conventional routing *******************************

                //endpoints.MapDefaultControllerRoute();

                //endpoints.MapControllerRoute(
                //    name: "AboutUs",
                //    pattern: "about-us/{id?}",
                //    defaults: new { controller = "Home", action = "AboutUs" });

                //************** Ending - Conventional routing *******************************

            });



        }
    }
}
