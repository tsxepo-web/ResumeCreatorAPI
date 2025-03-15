using Moq;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Features.Resume.GetResumeById;
using ResumeCreatorAPI.Features.Resume.UpdateResume;

namespace ResumeCreator.Tests.Handlers
{
    public class UpdateResumeHandlerTests
    {
        private readonly Mock<IUpdateResumeRepository> _mockRepository;
        private readonly Mock<IGetResumeByIdRepository> _mockGetByIdRepository;
        private readonly UpdateResumeHandler _handler;
        public UpdateResumeHandlerTests()
        {
            _mockRepository = new Mock<IUpdateResumeRepository>();
            _mockGetByIdRepository = new Mock<IGetResumeByIdRepository>();
            _handler = new UpdateResumeHandler(_mockRepository.Object, _mockGetByIdRepository.Object);
        }
        [Fact]
        public async Task Handle_Should_Return_Success_When_Resume_Exists()
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

            var updateCommand = new UpdateResumeCommand(
                "1",
                new PersonalInfo { Name = "John Updated" },
                new List<Education>(),
                new List<Experience>(),
                new List<Skill>(),
                new List<Certification>(),
                "UpdatedStyle"
            );
            _mockGetByIdRepository
           .Setup(repo => repo.GetResumeByIdAsync("1", It.IsAny<CancellationToken>()))
           .ReturnsAsync(resume);

            _mockRepository
                .Setup(repo => repo.UpdateResumeAsync(It.IsAny<Resume>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            Assert.True(result.Success);
            Assert.Equal("Resume updated successfully.", result.Message);

            _mockGetByIdRepository.Verify(r => r.GetResumeByIdAsync("1", It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(r => r.UpdateResumeAsync(It.IsAny<Resume>(), It.IsAny<CancellationToken>()), Times.Once);


        }
        [Fact]
    public async Task Handle_Should_Return_NotFound_When_Resume_Does_Not_Exist()
    {
        // Arrange
        _mockGetByIdRepository
            .Setup(repo => repo.GetResumeByIdAsync("999", It.IsAny<CancellationToken>()))
            .ReturnsAsync((Resume?)null);

        var updateCommand = new UpdateResumeCommand(
            "999",
            new PersonalInfo { Name = "Non-Existent" },
            new List<Education>(),
            new List<Experience>(),
            new List<Skill>(),
            new List<Certification>(),
            "Modern"
        );

            // Act
            var result = await _handler.Handle(updateCommand, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Resume with ID 999 not found.", result.Message);

            _mockGetByIdRepository.Verify(r => r.GetResumeByIdAsync("999", It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(r => r.UpdateResumeAsync(It.IsAny<Resume>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}