using System.Threading.Tasks;
using PlanningPokerApi.Src.Shared.Database.Repositories;
using PlanningPokerApi.Src.Shared.Database.Entities;

namespace PlanningPokerApi.Src.UseCases.Cards.Create
{
  public class CardsCreateBO
  {

    private CardRepository _repository;

    public CardsCreateBO(CardRepository repository)
    {
      _repository = repository;
    }

    internal async Task<CardsCreateResponseDto> Execute(CardsCreateRequestDto request)
    {
      var entity = CreateEntityWith(request);
      var result = await _repository.Create(entity);
      return CreateResponseWith(result);
    }

    private CardEntity CreateEntityWith(CardsCreateRequestDto request)
    {
      var entity = new CardEntity();
      entity.Value = request.Value;
      return entity;
    }

    private CardsCreateResponseDto CreateResponseWith(CardEntity result)
    {
      var response = new CardsCreateResponseDto();
      response.Id = result.Id;
      response.Value = result.Value;
      return response;
    }
  }
}