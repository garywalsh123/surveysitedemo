using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SurveySite.BusinessLogic.Contract;
using SurveySite.DTOs;

namespace SurveySite.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionBl mQuestionBl;

        public QuestionsController(IQuestionBl questionBl)
        {
            mQuestionBl = questionBl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("banks")]
        public async Task<IActionResult> GetQuestionBanks()
        {
            var banks = await mQuestionBl.GetQuestionBanks();
            return new OkObjectResult(banks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="surveyBankId"></param>
        /// <returns></returns>
        [HttpGet("banks/questionBankId")]
        public async Task<IActionResult> GetQuestionBankById([FromQuery] Guid questionBankId)
        {
            var banks = await mQuestionBl.GetQuestionsByQuestionBank(questionBankId);
            return new OkObjectResult(banks);
        }
    }
}
