using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlanningPokerApi.Src.UseCases.Users.Create
{
  [Route("api/users/create")]
  [ApiController]
  public class UsersCreateController : ControllerBase
  {

    private UsersCreateBO _bo;

    public UsersCreateController(UsersCreateBO bo)
    {
      _bo = bo;
    }

    [HttpPost("")]
    public async Task<ActionResult<UsersCreateResponseDto>> Handle([FromBody] UsersCreateRequestDto request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _bo.Execute(request));
    }
  }
}