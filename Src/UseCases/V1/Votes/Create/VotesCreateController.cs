using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Votes.Create
{

  [Route("api/v1/votes/create")]
  [ApiController]
  public class VotesCreateController : ControllerBase
  {

    private readonly IBusiness<VotesCreateRequestDto, VotesCreateResponseDto> _business;

    public VotesCreateController(IBusiness<VotesCreateRequestDto, VotesCreateResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    public async Task<ActionResult<VotesCreateResponseDto>> Handle([FromBody] VotesCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(request));
    }
  }
}