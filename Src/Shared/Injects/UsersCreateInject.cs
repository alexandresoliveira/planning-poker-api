using Microsoft.Extensions.DependencyInjection;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;
using PlanningPokerApi.Src.UseCases.V1.Users.Create;

namespace PlanningPokerApi.Src.Shared.Injects
{
  public class UsersCreateInject
  {
    public void Invoke(IServiceCollection services)
    {
      services.AddScoped<IRepository<UserEntity>, UserRepository>();
      services.AddScoped<UsersCreateBO, UsersCreateBO>();
    }
  }
}