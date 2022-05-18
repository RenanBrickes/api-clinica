using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="O campo Username é obrigatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="O campo Password é obrigatorio.")]
        public string Password { get; set; }
    }
}
