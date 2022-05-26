using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.GetUserById
{
    public class GetUserByIdQueryResult
    {
        public GetUserByIdQueryResult(string idUser, string name, string cellPhone, string email)
        {
            IdUser = idUser;
            Name = name;
            CellPhone = cellPhone;
            Email = email;
        }

        public string IdUser { get; set; }
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }

    }
}
