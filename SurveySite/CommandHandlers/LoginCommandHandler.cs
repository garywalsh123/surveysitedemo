using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SurveySite.CommandHandlers.Commands;
using SurveySite.CommandHandlers.Results;
using SurveySite.Database;
using SurveySite.Database.Models;
using SurveySite.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveySite.CommandHandlers
{
    public class LoginCommadHandler : ICommandHandler<LoginCommand, LoginResult>
    {
        private readonly SurveySiteContext _context;
        private readonly UserManager<User> mUserManager;
        private readonly IConfiguration mConfiguration;

        public LoginCommadHandler(
            SurveySiteContext context,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _context = context;
            mUserManager = userManager;
            mConfiguration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="SurveyException"></exception>
        public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken = default)
        {
            var user = await mUserManager.FindByNameAsync(command.UserName);

            if (user is null || !await mUserManager.CheckPasswordAsync(user, command.Password))
            {
                throw new ArgumentException($"Invalid login attempt");
            }

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = GetToken(authClaims);

            return new LoginResult()
            {
                Jwt = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mConfiguration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: mConfiguration["JWT:ValidIssuer"],
                audience: mConfiguration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
