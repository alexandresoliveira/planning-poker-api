using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.UseCases.V1.UsersHistory.Create;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class UsersHistoryCreateInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<UsersHistoryRepository, UsersHistoryRepository>();
      services.AddScoped<UsersHistoryCreateBO, UsersHistoryCreateBO>();
    }
  }
}