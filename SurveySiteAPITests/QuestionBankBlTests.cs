using AutoFixture.Xunit2;
using AutoMapper;
using Moq;
using SurveySite.BusinessLogic.Implementation;
using SurveySite.DTOs;
using SurveySite.Infrastructure;
using SurveySite.QueryHandlers.Queries;
using FluentAssertions;

namespace SurveySiteAPITests
{
    [Trait("Category", "SurveySiteDemo: BusinessLogic")]
    [Trait("Description", "QuestionBankBl Tests")]
    public class QuestionBankBlTests
    {
        [Theory, AutoData]
        public async void GetBanks_ShouldReturn_Banks(
            [Frozen] Mock<IMapper> mapperMock,
            [Frozen] Mock<IMediator> mediatorMock,
            [NoAutoProperties] GetQuestionBankResult results,
            QuestionBankResultDto dtoResults
            )
        {
            mapperMock
                .Setup(m => m.Map<QuestionBankResultDto>(results))
                .Returns(dtoResults);

            mediatorMock.Setup(svc =>
                    svc.Execute<GetQuestionBankQuery, GetQuestionBankResult>(It.IsAny<GetQuestionBankQuery>(),It.IsAny<CancellationToken>()))
                    .ReturnsAsync(results);

            var sut = new QuestionBankBl(mapperMock.Object, mediatorMock.Object);
            var actualResult = await sut.GetQuestionBanks();
            actualResult.Should().Be(dtoResults);
        }
    }
}