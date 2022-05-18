using Application.Response;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Login
{
    public class LoginCommandResult
    {
        public LoginCommandResult(string token, string usuario)
        {
            Token = token;
            Usuario = usuario;
        }

        public string Token { get; set; }
        public string Usuario { get; set; }

    }
}
