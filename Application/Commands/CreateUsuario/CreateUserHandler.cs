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
    public class CreateUserHandler : IRequestHandler<CreateUserCommandInput, Response<CreateUserCommandInput>>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly UserManager<Usuario> _userManager;

        public CreateUserHandler(IUsuarioService usuarioService, UserManager<Usuario> userManager)
        {
            _usuarioService = usuarioService;
            _userManager = userManager;
        }

        public async Task<Response<CreateUserCommandInput>> Handle(CreateUserCommandInput request, CancellationToken cancellationToken)
        {

            //Validate password
            bool Isvalid = _usuarioService.ValidadePassword(request.Password);

            if(!Isvalid)
                return new Response<CreateUserCommandInput>(false, $"A senha digitada não é valida, é necessário ter um caractere maiúsculo, uma minusculo, um número, um símbolo e até 6 caráteres.");

            //Validate have another user with username
            if (_usuarioService.HaveUserByUsername(request.Username))
                return new Response<CreateUserCommandInput>(false, $"Já existe um usuário com esse Username : {request.Username}");

            //Define user creation class
            Usuario usuarioCreate = new Usuario
            {
                Nome = request.Name,
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.CellPhone,
                EmailConfirmed = true
            };

            //try create user
            bool userCreated = await _usuarioService.Create(usuarioCreate, request.Password);

            if (userCreated)
                return new Response<CreateUserCommandInput>(true, "Usuário criado com sucesso!");

            return new Response<CreateUserCommandInput>(false, "Não foi possível criar o usuário, tente novamente ou mais tarde.!");
        }
    }
}
