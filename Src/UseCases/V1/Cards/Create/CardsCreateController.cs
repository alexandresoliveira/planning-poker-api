using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Cards.Create
{

  [Route("api/v1/cards/create")]
  [ApiController]
  public class CardsCreateController : ControllerBase
  {

    private IBusiness<CardsCreateRequestDto, CardsCreateResponseDto> _business;

    public CardsCreateController(IBusiness<CardsCreateRequestDto, CardsCreateResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    public async Task<ActionResult<CardsCreateResponseDto>> Handle([FromBody] CardsCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(request));
    }
  }
}