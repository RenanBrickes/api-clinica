using Application.Response;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CreateUsuario
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommandInput, Response<DeleteUserCommandInput>>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly UserManager<Usuario> _userManager;

        public DeleteUserHandler(IUsuarioService usuarioService, UserManager<Usuario> userManager)
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
        }

        public async Task<Response<DeleteUserCommandInput>> Handle(DeleteUserCommandInput request, CancellationToken cancellationToken)
        {

            return new Response<DeleteUserCommandInput>(false, "Não foi possível deletar o usuário, tente novamente ou mais tarde.!");
        }
    }
}
