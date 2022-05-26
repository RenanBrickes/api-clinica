using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.GetUsers
{
    public class GetUsersQueryInput : IRequest<ResponsePaged<List<GetUsersQueryResult>>>
    {
        public GetUsersQueryInput(int count = 0)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}
