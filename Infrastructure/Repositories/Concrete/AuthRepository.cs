using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestFullAPI.Infrastructure.Context;
using RestFullAPI.Infrastructure.Repositories.Interface;
using RestFullAPI.Infrastructure.Settings;
using RestFullAPI.Models.Entities.Concrete;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RestFullAPI.Infrastructure.Repositories.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public AuthRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public AppUser Authentication(string userName, string password)
        {
            AppUser user = _context.AppUsers.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            if (user == null) return null;
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                return user;
            }
        }
    }
}
