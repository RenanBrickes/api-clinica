using Application.Response;
using Domain.Entites;
using MediatR;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryInput, ResponsePaged<List<GetUsersQueryResult>>>
    {
        private readonly IUsuarioService _usuarioService;

        public GetUsersQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<ResponsePaged<List<GetUsersQueryResult>>> Handle(GetUsersQueryInput request, CancellationToken cancellationToken)
        {
            try
            {
                //Get all users
                IQueryable<Usuario> getUsers = await _usuarioService.GetUsers();

                //Count user return
                int totalUsers = getUsers.Count();

                //Return users filtred
                List<GetUsersQueryResult> userList = getUsers
                    .Skip(request.Count)
                    .Take(2)
                    .Select(u => new GetUsersQueryResult(u))
                    .ToList();

                int remaining = totalUsers - (userList.Count() + request.Count);

                //Create class from retrun
                return new ResponsePaged<List<GetUsersQueryResult>>(totalUsers, userList.Count(), remaining, true, "Lista de usuário.", userList);
            }
            catch
            {
                return new ResponsePaged<List<GetUsersQueryResult>>(0, 0, 0, false, "Não foi possivél obter a lista de usuário.");
            }
        }
    }
}
