using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanningPokerApi.Src.UseCases.V1.Votes.Create
{

  [Route("api/v1/votes/create")]
  [ApiController]
  public class VotesCreateController : ControllerBase
  {

    private VotesCreateBO _bo;

    public VotesCreateController(VotesCreateBO bo)
    {
      _bo = bo;
    }

    [HttpPost("")]
    public async Task<ActionResult<VotesCreateResponseDto>> Handle([FromBody] VotesCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _bo.Execute(request));
    }
  }
}