using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanningPokerApi.Src.UseCases.Cards.Create
{
  [Route("api/cards/create")]
  [ApiController]
  public class CardsCreateController : ControllerBase
  {

    private CardsCreateBO _bo;

    public CardsCreateController(CardsCreateBO bo)
    {
      _bo = bo;
    }

    [HttpPost("")]
    public async Task<ActionResult<CardsCreateResponseDto>> Handle(CardsCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _bo.Execute(request));
    }
  }
}