using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Cms.Services.Models.Auth;
using Cms.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete.Api
{
    internal class AuthService : IAuthService
    {
        private IDataRepository<UserEntity> UserRepository { get; }
        private IConfiguration Configuration { get; }
        private ILogger<AuthService> Logger { get; }

        public AuthService(IDataRepository<UserEntity> userRepository, IConfiguration config, ILogger<AuthService> logger)
        {
            UserRepository = userRepository;
            Configuration = config;
            Logger = logger;
        }

        public async Task<IServiceResult<TokenResponseModel>> LoginAsync(string name, string password, CancellationToken cancellationToken)
        {
            try
            {
                var user = await UserRepository.GetAll()
                    .SingleOrDefaultAsync(x => x.Name == name && x.Password == password, cancellationToken);

                if (user == null)
                {
                    return ServiceResult.Fail<TokenResponseModel>("Invalid username or password", StatusCodes.Status401Unauthorized);
                }

                return ServiceResult.Success(new TokenResponseModel
                {
                    Token = CreateJwt(user)
                });
            }
            catch (OperationCanceledException ocex)
            {
                Logger.LogWarning(ocex, "Operation cancelled.");
                return ServiceResult.Fail<TokenResponseModel>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error while logging in");
                return ServiceResult.Fail<TokenResponseModel>("Error while logging in", StatusCodes.Status500InternalServerError);
            }
        }

        private string CreateJwt(UserEntity user)
        {
            var issuer = Configuration["Jwt:Issuer"];
            var audience = Configuration["Jwt:Audience"];
            var keyBytes = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
            var key = new SymmetricSecurityKey(keyBytes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddSeconds(30),
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Name, user.Name),
                        new Claim(JwtRegisteredClaimNames.FamilyName, user.Surname),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("UserId", user.Id.ToString()),
                    }),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}
