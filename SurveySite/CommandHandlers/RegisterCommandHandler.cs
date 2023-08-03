using Microsoft.AspNetCore.Identity;
using SurveySite.CommandHandlers.Commands;
using SurveySite.CommandHandlers.Results;
using SurveySite.Database;
using SurveySite.Database.Models;
using SurveySite.Infrastructure;

namespace SurveySite.CommandHandlers
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterResult>
    {
        private readonly SurveySiteContext _context;
        private readonly UserManager<User> mUserManager;
        private readonly IConfiguration mConfiguration;

        public RegisterCommandHandler(
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
        /// <exception cref="ArgumentException"></exception>
        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken = default)
        {
            var userByEmail = await mUserManager.FindByEmailAsync(command.UserName);
            if (userByEmail is not null )
            {
                throw new SurveyException($"Username already registered");
            }

            User user = new()
            {
                UserName = command.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await mUserManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                throw new SurveyException($"Unable to register user your account. Please try again.");
            }

            return new RegisterResult() { 
                UserName = user.UserName
            };
        }
    }

}
