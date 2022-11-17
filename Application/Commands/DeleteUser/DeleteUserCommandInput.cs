using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Commands.CreateUsuario
{
    public class DeleteUserCommandInput : IRequest<Response<DeleteUserCommandInput>>
    {
        public DeleteUserCommandInput(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
