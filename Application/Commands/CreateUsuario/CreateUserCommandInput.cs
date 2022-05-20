using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Commands.CreateUsuario
{
    public class CreateUserCommandInput : IRequest<Response<CreateUserCommandInput>>
    {
        public CreateUserCommandInput(string name, string username, string email, string password, string cellphone)
        {
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            CellPhone = cellphone;
        }

        public string Name { get; set; }

        public string Username { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string CellPhone { get; set; }
    }
}
