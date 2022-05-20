using Application.Response;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using Service.Interface;

namespace Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandInput, Response<LoginCommandResult>>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IUsuarioService _usuarioService;

        public LoginCommandHandler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IUsuarioService usuarioService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioService = usuarioService;
        }

        public async Task<Response<LoginCommandResult>> Handle(LoginCommandInput request, CancellationToken cancellationToken)
        {
            //Validate user data
            string mensageValidate = request.InputValidate();

            //if you have validation message
            if (!string.IsNullOrEmpty(mensageValidate))
                return new Response<LoginCommandResult>(false, mensageValidate); 

            //Validate username of login
            Usuario usuario = await _userManager.FindByNameAsync(request.UserName);
            
            //if not have user with username
            if (usuario is null)
                return new Response<LoginCommandResult>(false, "Não há nenhum usuário com esse Username.");

            //Try login
            SignInResult isLogin = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);
            
            //If user is login
            if (isLogin.Succeeded)
            {
                string userToken = _usuarioService.GetToken(usuario);
                LoginCommandResult commandResult = new LoginCommandResult(userToken, usuario.Nome);
                return new Response<LoginCommandResult>(true, "Usuário logado.", commandResult);
            }

            return new Response<LoginCommandResult>(false, "Não foi possível realizar o login, tente novamente ou mais tarde.");
        }
    }
}
