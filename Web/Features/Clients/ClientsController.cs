using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Features.Clients.Queries;

namespace Web.Features.Clients;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAllClients.GetAllClientsResult>>> GetAsync()
    {
        var result = await _mediator.Send(new GetAllClients.GetClientsQuery());

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<GetById.GetClientResponse>>> GetByIdAsync([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetById.GetClientQuery(id));

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
 
