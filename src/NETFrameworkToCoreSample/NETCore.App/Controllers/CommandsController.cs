using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCore.App.Contracts;
using Newtonsoft.Json;

namespace NETCore.App.Controllers
{
[ApiController]
[Route("api")]
public class CommandsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("commands")]
    public async Task<IActionResult> ExecuteCommand(RequestDto requestDto)
    {
        Type type = GetCommandsAssembly().GetType(requestDto.Type);
        dynamic command = JsonConvert.DeserializeObject(requestDto.Data, type);

        await _mediator.Send(command);

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("commands-with-result")]
    public async Task<IActionResult> ExecuteCommandWithResult(RequestDto requestDto)
    {
        Type type = GetCommandsAssembly().GetType(requestDto.Type);
        dynamic command = JsonConvert.DeserializeObject(requestDto.Data, type);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    private Assembly GetCommandsAssembly()
    {
        return typeof(AddProductCommand).Assembly;
    }
}
}
