using System.Threading.Tasks;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;

namespace PlanningPokerApi.Src.UseCases.Users.Create
{
  public class UsersCreateBO
  {

    private UserRepository _repository;

    public UsersCreateBO(UserRepository repository)
    {
      _repository = repository;
    }

    internal async Task<UsersCreateResponseDto> Execute(UsersCreateRequestDto requestDto)
    {
      var entity = CreateEntityWith(requestDto);
      var result = await _repository.Create(entity);
      return CreateResponseWith(result);
    }

    private UserEntity CreateEntityWith(UsersCreateRequestDto Dto)
    {
      var entity = new UserEntity();
      entity.Name = Dto.Name;
      return entity;
    }

    private UsersCreateResponseDto CreateResponseWith(UserEntity entity)
    {
      var Dto = new UsersCreateResponseDto();
      Dto.Id = entity.Id;
      Dto.Name = entity.Name;
      return Dto;
    }
  }
}