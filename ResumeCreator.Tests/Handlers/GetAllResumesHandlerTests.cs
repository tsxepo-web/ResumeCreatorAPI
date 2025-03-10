using Moq;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.GetResume;

namespace ResumeCreator.Tests.Handlers
{
    public class GetAllResumesHandlerTests
    {
        private readonly Mock<IGetAllResumesRepository> _mockRepository;
        private readonly GetAllResumesHandler _handler;

        public GetAllResumesHandlerTests()
        {
            _mockRepository = new Mock<IGetAllResumesRepository>();
            _handler = new GetAllResumesHandler(_mockRepository.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_All_Resumes()
        {
            // Arrange
            var resumes = new List<Resume>
            {
                new Resume(
                new PersonalInfo { Name = "John Doe" },
                new List<Education>(),
                new List<Experience>(),
                new List<Skill>(),
                new List<Certification>(),
                "Modern"
            ) { Id = "1" },

            new Resume(
                new PersonalInfo { Name = "Jane Doe" },
                new List<Education>(),
                new List<Experience>(),
                new List<Skill>(),
                new List<Certification>(),
                "Classic"
            ) { Id = "2" }
            };

            _mockRepository
                .Setup(repo => repo.GetAllResumesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(resumes);

            var request = new GetAllResumesQuery();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Resumes);
            Assert.Equal(2, result.Resumes.Count);
            Assert.Equal("John Doe", result.Resumes[0].PersonalInfo?.Name);
            Assert.Equal("Jane Doe", result.Resumes[1].PersonalInfo?.Name);

            _mockRepository.Verify(r => r.GetAllResumesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}