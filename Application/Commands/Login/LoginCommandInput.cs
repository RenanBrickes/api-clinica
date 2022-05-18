using Application.Response;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Login
{
    public class LoginCommandInput : IRequest<Response<LoginCommandResult>>
    {
        public LoginCommandInput(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        public string InputValidate()
        {
            if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
                return "UserName e Password são obrigatórios.";
            else if (string.IsNullOrEmpty(UserName))
                return "UserName é Obrigatório.";
            else if (string.IsNullOrEmpty(Password))
                return "Password é Obrigatório.";
            return "";
        }
    }
}
