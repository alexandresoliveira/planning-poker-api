using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanningPokerApi.Src.UseCases.V1.UsersHistory.Create
{

  [Route("api/v1/users-histories/create")]
  [ApiController]
  public class UsersHistoryCreateController : ControllerBase
  {

    private UsersHistoryCreateBO _bo;

    public UsersHistoryCreateController(UsersHistoryCreateBO bo)
    {
      _bo = bo;
    }

    [HttpPost("")]
    public async Task<ActionResult<UsersHistoryCreateResponseDto>> Handle([FromBody] UsersHistoryCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _bo.Execute(request));
    }
  }
}