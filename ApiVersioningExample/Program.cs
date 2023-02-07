using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ApiVersioningExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddMvc(setupAction: o =>
            {
                o.EnableEndpointRouting = false;
                o.ModelBinderProviders.RemoveType<DateTimeModelBinderProvider>();
            }).AddRazorPagesOptions(options =>
            {
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapAreaControllerRoute(
              name: "clients",
              areaName: "Clients",
              pattern: "Clients/{controller}/{action}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}