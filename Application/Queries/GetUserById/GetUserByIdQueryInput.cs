using Application.Queries.GetUsers;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.GetUserById
{
    public class GetUserByIdQueryInput : IRequest<Response<GetUserByIdQueryResult>>
    {
        public GetUserByIdQueryInput(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
