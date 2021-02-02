using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.Shared.Business;
using PlanningPokerApi.Src.UseCases.V1.Authentication;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class AuthenticationInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<IBusiness<AuthenticationRequestDto, AuthenticationResponseDto>, AuthenticationBusiness>();
    }
  }
}