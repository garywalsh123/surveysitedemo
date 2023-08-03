using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SurveySite.BusinessLogic.Contract;
using SurveySite.DTOs;

namespace SurveySite.Controllers
{
    [Route("api/survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyBl mSurveyBl;

        public SurveyController(ISurveyBl surveyBl)
        {
            mSurveyBl = surveyBl;
        }

        // POST api/<QuestionController>
        /// <summary>
        /// Create a survey context for a customer
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> StartSurvey([FromBody] Guid? customerIdentifier)
        {
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var response = await mSurveyBl.CreateSurvey(customerIdentifier, ipAddress.ToString());
            return new OkObjectResult(response);
        }

        // POST api/<QuestionController>
        /// <summary>
        /// Save an answer in the survey
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> AnswerQuestion([FromBody] SurveyAnswerDto answer)
        {
            await mSurveyBl.AnswerQuestion(answer);
            return new OkResult();
        }
    }
}
