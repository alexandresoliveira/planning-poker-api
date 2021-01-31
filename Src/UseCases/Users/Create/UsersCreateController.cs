using System;
using System.Collections.Generic;
using System.Linq;
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
    public async Task<ActionResult<UsersCreateResponseDTO>> Handle(UsersCreateRequestDTO request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      return CreatedAtAction(nameof(Handle), await _bo.Execute(request));
    }
  }
}