using Moq;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.GetResumeById;

namespace ResumeCreator.Tests.Handlers
{
    public class GetResumeByIdTests
    {
        private readonly Mock<IGetResumeByIdRepository> _mockRepository;
        private readonly GetResumeByIdHandler _handler;
        public GetResumeByIdTests()
        {
            _mockRepository = new Mock<IGetResumeByIdRepository>();
            _handler = new GetResumeByIdHandler(_mockRepository.Object);
        }
        [Fact]
        public async Task Handle_Should_Return_Resume_When_Found()
        {
            var resume = new Resume(
            new PersonalInfo { Name = "John Doe" },
            new List<Education>(),
            new List<Experience>(),
            new List<Skill>(),
            new List<Certification>(),
            "Modern"
            )
            { Id = "1" };

            _mockRepository
                .Setup(repo => repo.GetResumeByIdAsync("1", It.IsAny<CancellationToken>()))
                .ReturnsAsync(resume);

            var query = new GetResumeByIdQuery("1");
            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("1", result.Resume?.Id);
            Assert.Equal("John Doe", result.Resume?.PersonalInfo.Name);

            _mockRepository.Verify(r => r.GetResumeByIdAsync("1", It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}