using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanningPokerApi.Src.Shared.Business;

namespace PlanningPokerApi.Src.UseCases.V1.Authentication
{

  [ApiController]
  [Route("api/v1/authentication")]
  public class AuthenticationController : ControllerBase
  {

    private readonly IBusiness<AuthenticationRequestDto, AuthenticationResponseDto> _business;

    public AuthenticationController(IBusiness<AuthenticationRequestDto, AuthenticationResponseDto> business)
    {
      _business = business;
    }

    [HttpPost("")]
    public async Task<ActionResult<AuthenticationResponseDto>> Handle([FromBody] AuthenticationRequestDto dto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _business.Execute(dto));
    }
  }
}