using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectMobile.Models;
using ProjectMobile.VModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobile.Repositories
{
    public class AccountRepository
    {
        private readonly ProjectMobileContext _context;
        private readonly IConfiguration _config;
        public AccountRepository(ProjectMobileContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public AccountVModel CheckLogin(string accountID,string password)
        {
            
            Account acc = _context.Account
                .Where(record => record.AccountId == accountID && record.Password == password)
                .FirstOrDefault();

            string token = GenerateJSONWebToken(acc);
            AccountVModel accVmodel = new AccountVModel()
            {
                AccountId = acc.AccountId,
                Password = acc.Password,
                Role = acc.Role,
                Token = token
            };

            return accVmodel;
        }
        private string GenerateJSONWebToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountId + ""),
                    new Claim(ClaimTypes.Role, account.Role + "")
                }),
                Audience = _config["Jwt:Issuer"],
                Issuer = _config["Jwt:Issuer"],
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
