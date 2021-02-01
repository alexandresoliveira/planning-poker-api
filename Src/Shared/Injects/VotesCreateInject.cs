using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.UseCases.V1.Votes.Create;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class VotesCreateInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<VotesRepository, VotesRepository>();
      services.AddScoped<UserRepository, UserRepository>();
      services.AddScoped<UsersHistoryRepository, UsersHistoryRepository>();
      services.AddScoped<CardRepository, CardRepository>();
      services.AddScoped<VotesCreateBO, VotesCreateBO>();
    }
  }
}