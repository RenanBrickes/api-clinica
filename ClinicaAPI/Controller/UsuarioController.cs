using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.CreateUsuario;
using Application.Queries.GetUserById;
using Application.Queries.GetUsers;
using ClinicaAPI.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controller
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int count, CancellationToken cancellationToken)
        {
            GetUsersQueryInput queryInput = new GetUsersQueryInput(count);
            return Ok(await _mediator.Send(queryInput, cancellationToken));
        }

        [HttpGet("{userId:Guid}/details")]
        public async Task<IActionResult> DetailsUser(Guid userId, CancellationToken cancellationToken)
        {
            GetUserByIdQueryInput getUserByIdQuery = new GetUserByIdQueryInput(userId);
            return Ok(await _mediator.Send(getUserByIdQuery, cancellationToken));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UsuarioRequest usuarioRequest, CancellationToken cancellationToken)
        {
            CreateUserCommandInput createUsuarioCommand = new CreateUserCommandInput(usuarioRequest.Name, usuarioRequest.Username, usuarioRequest.Email, usuarioRequest.Password, usuarioRequest.CellPhone);
            return Ok(await _mediator.Send(createUsuarioCommand, cancellationToken));
        }
    }
}
