using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tp03.Core.Data;
using Tp03.Core.Services.BillOfLadingServices;
using Tp03.Core.Services.ContainerServices;

namespace Tp03.WebApplication
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

      services.AddDbContext<Tp03Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),  action => action.MigrationsAssembly("Tp03.WebApplication")));

      services.AddScoped<Tp03Context>();

      services.AddScoped<AddContainerService>();
      services.AddScoped<DeleteContainerService>();
      services.AddScoped<ListContainerService>();
      services.AddScoped<UpdateContainerService>();
      services.AddScoped<AddBillOfLadingService>();
      services.AddScoped<DeleteBillOfLadingService>();
      services.AddScoped<ListBillOfLadingService>();
      services.AddScoped<UpdateBillOfLadingService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Container}/{action=Index}/{id?}");
      });
    }
  }
}
