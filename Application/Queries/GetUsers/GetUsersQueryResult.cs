using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.GetUsers
{
    public class GetUsersQueryResult
    {
        public GetUsersQueryResult(Usuario usuario)
        {
            IdUser = usuario.Id;
            Name = usuario.Nome;
            CellPhone = usuario.PhoneNumber;
            Email = usuario.Email;
        }

        public string IdUser { get; set; }
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}
