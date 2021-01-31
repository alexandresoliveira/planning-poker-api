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

    internal async Task<UsersCreateResponseDTO> Execute(UsersCreateRequestDTO requestDTO)
    {
      var entity = CreateEntityWith(requestDTO);
      var result = await _repository.Create(entity);
      return CreateResponseWith(result);
    }

    private UserEntity CreateEntityWith(UsersCreateRequestDTO dto)
    {
      var entity = new UserEntity();
      entity.Name = dto.Name;
      return entity;
    }

    private UsersCreateResponseDTO CreateResponseWith(UserEntity entity)
    {
      var dto = new UsersCreateResponseDTO();
      dto.Id = entity.Id;
      dto.Name = entity.Name;
      return dto;
    }
  }
}