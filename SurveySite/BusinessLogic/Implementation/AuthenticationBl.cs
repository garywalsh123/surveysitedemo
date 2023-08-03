using AutoMapper;
using SurveySite.BusinessLogic.Contract;
using SurveySite.CommandHandlers;
using SurveySite.CommandHandlers.Commands;
using SurveySite.CommandHandlers.Results;
using SurveySite.Database;
using SurveySite.DTOs;
using SurveySite.Infrastructure;

namespace SurveySite.BusinessLogic.Implementation
{
    public class AuthenticationBl : IAuthenticationBl
    {
        private readonly IMapper mMapper;
        private readonly IMediator mMediator;

        public AuthenticationBl(IMapper mapper, IMediator mediator)
        {
            mMapper = mapper;
            mMediator = mediator;
        }

        /// <inheritdoc />
        public async Task<LoginResponseDto> LoginUser(LoginRequestDto loginRequest)
        {
            var response = await mMediator.Send<LoginCommand, LoginResult>(new LoginCommand()
            {
                UserName = loginRequest.UserName,
                Password = loginRequest.Password
            });
            return mMapper.Map<LoginResponseDto>(response);
        }

        /// <inheritdoc />
        public async Task<RegisterResponseDto> RegisterUser(RegisterRequestDto registerRequest)
        {
            var response = await mMediator.Send<RegisterCommand, RegisterResult>(new RegisterCommand()
            {
                UserName = registerRequest.UserName,
                Password = registerRequest.Password
            });
            return mMapper.Map<RegisterResponseDto>(response);
        }
    }
}
