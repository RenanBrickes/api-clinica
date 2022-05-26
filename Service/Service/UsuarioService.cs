using Domain.Entites;
using Infra.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUserRepository _userRepository;


        public UsuarioService(IConfiguration configuration, UserManager<Usuario> userManager, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<bool> Create(Usuario usuario, string password)
        {
            //Create user
            IdentityResult identityResult = await _userManager.CreateAsync(usuario, password);
            //If user created 
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(usuario, "Usuario");
                return true;
            }

            return false;
        }

        public async Task<IQueryable<Usuario>> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public async Task<Usuario> GetUserById(Guid userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public string GetToken(Usuario usuario)
        {
            return BuildToken(usuario);
        }

        public bool HaveUserByUsername(string username)
        {
            List<Usuario> usuario = _userRepository
                    .GetUsers()
                        .Where(u => u.UserName == username)
                            .ToList();

            return usuario is null ? false : usuario.Count() > 0;
        }

        public bool ValidadePassword(string password)
        {
            //a capital character
            if (!new Regex("[A-Z]").IsMatch(password))
                return false;
            //a lowercase character
            if (!new Regex("[a-z]").IsMatch(password))
                return false;
            //one digit
            if (!new Regex("[0-9]").IsMatch(password))
                return false;
            //non-alphanumeric character
            if (!new Regex("[#$%&*+_.@~]").IsMatch(password))
                return false;
            //requerid size has 6 character
            if (password.Count() < 6)
                return false;

            return true;
        }

        private string BuildToken(Usuario usuario)
        {

            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name,usuario.Nome),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
