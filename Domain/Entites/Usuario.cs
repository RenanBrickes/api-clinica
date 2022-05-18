using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entites
{
    public class Usuario : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

    }
}
