using Application.Response;
using Domain.Entites;
using MediatR;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryInput, Response<GetUserByIdQueryResult>>
    {
        private readonly IUsuarioService _userService;

        public GetUserByIdQueryHandler(IUsuarioService userService)
        {
            _userService = userService;
        }

        public async Task<Response<GetUserByIdQueryResult>> Handle(GetUserByIdQueryInput request, CancellationToken cancellationToken)
        {
            try
            {
                //Get User
                Usuario user = await _userService.GetUserById(request.Id);

                //If there is no user
                if (user == null)
                    return new Response<GetUserByIdQueryResult>(false, "Não foi possível localizar o usuário com esse ID.");

                GetUserByIdQueryResult userResult = new GetUserByIdQueryResult(user.Id, user.Nome, user.PhoneNumber, user.Email);
                
                return new Response<GetUserByIdQueryResult>(true, "Usuário encontrado.", userResult);
            }
            catch
            {
                return new Response<GetUserByIdQueryResult>(false, "Não foi possível localizar o usuário.");
            }

        }
    }
}
