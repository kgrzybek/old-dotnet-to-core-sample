using System;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.App.Contracts;
using Newtonsoft.Json;

namespace NETCore.App.Controllers
{
[ApiController]
[Route("api")]
public class QueriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public QueriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("queries")]
    public async Task<IActionResult> ExecuteQuery(RequestDto requestDto)
    {
        Type type = GetQueriesAssembly().GetType(requestDto.Type);
        dynamic query = JsonConvert.DeserializeObject(requestDto.Data, type);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    private Assembly GetQueriesAssembly()
    {
        return typeof(GetProductsQuery).Assembly;
    }
}
}