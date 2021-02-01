using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using PlanningPokerApi.Src.Shared.Database.Contexts;
using PlanningPokerApi.Src.Shared.Injects;
using PlanningPokerApi.Src.Shared.Hubs;

namespace PlanningPokerApi
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
      services.AddDbContext<ApiContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PlanningPokerApiConnectionUrl")));
      services.AddScoped<ApiContext, ApiContext>();

      new UsersCreateInject().Invoke(services);
      new CardsCreateInject().Invoke(services);
      new UsersHistoryCreateInject().Invoke(services);
      new VotesCreateInject().Invoke(services);

      services.AddControllers();
      services.AddSignalR();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapHub<VoteHub>("/vote-register");
      });
    }
  }
}
