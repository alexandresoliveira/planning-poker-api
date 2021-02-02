using System;
using System.Text;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PlanningPokerApi.Src.Shared.Database.Contexts;
using PlanningPokerApi.Src.Shared.Injects;
using PlanningPokerApi.Src.Shared.Hubs;
using PlanningPokerApi.Src.Shared.Helpers.Jwt;

namespace PlanningPokerApi
{
  public class Startup
  {

    readonly string MyAllowSpecificOrigins = "@PlanningPokerApi.CorsPolicyDefault";

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

      services.AddScoped<JwtHelper, JwtHelper>();

      services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

      new UsersCreateInject().Invoke(services);
      new CardsCreateInject().Invoke(services);
      new UsersHistoryCreateInject().Invoke(services);
      new VotesCreateInject().Invoke(services);
      new AuthenticationInject().Invoke(services);

      services.AddControllers();
      services.AddSignalR();

      services.AddCors(
        options =>
        options.AddPolicy(
          name: MyAllowSpecificOrigins,
          builder =>
          {
            builder
              .WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
              .AllowAnyMethod();
          }));

      var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSettings").GetValue<string>("Secret"));

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(MyAllowSpecificOrigins);

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapHub<VoteHub>("/vote-register");
      });
    }
  }
}
