using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.CreateUsuario;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create(UsuarioRequest usuarioRequest, CancellationToken cancellationToken)
        {
            CreateUserCommandInput createUsuarioCommand = new CreateUserCommandInput(usuarioRequest.Name, usuarioRequest.Username, usuarioRequest.Email, usuarioRequest.Password, usuarioRequest.CellPhone);
            return Ok(await _mediator.Send(createUsuarioCommand, cancellationToken));
        }
    }
}
