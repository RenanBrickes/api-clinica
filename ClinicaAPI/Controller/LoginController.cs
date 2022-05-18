using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Login;
using ClinicaAPI.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controller
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("authetication")]
        public async Task<IActionResult> Authetication(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            //Set command from mediator
            LoginCommandInput loginCommand = new LoginCommandInput(loginRequest.Username, loginRequest.Password);

            return Ok(await _mediator.Send(loginCommand, cancellationToken));
        }
    }
}
