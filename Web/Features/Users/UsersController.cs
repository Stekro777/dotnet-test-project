using System;

using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Features.Clients.Queries;
using Web.Features.Users.Queries;

namespace Web.Features.Users;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<GetUserResponse>>> Get([FromRoute] int id)
    {
        var command = new GetUserQuery(id);
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllUsersResponse>>> GetAll()
    {
        var command = new GetAllUsersQuery();
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
}



