using SurveySite.CommandHandlers.Commands;
using SurveySite.CommandHandlers.Results;
using SurveySite.DTOs;
using SurveySite.QueryHandlers.Queries;

namespace SurveySite.BusinessLogic.Contract
{
    public interface IAuthenticationBl
    {
        /// <summary>
        /// Attempt to login as a user
        /// </summary>
        /// <returns></returns>
        public Task<LoginResponseDto> LoginUser(LoginRequestDto loginRequest);

        /// <summary>
        /// Sign up as a user
        /// </summary>
        /// <param name="questionBankId"></param>
        /// <returns></returns>
        public Task<RegisterResponseDto> RegisterUser(RegisterRequestDto registerRequest);
    }
}
