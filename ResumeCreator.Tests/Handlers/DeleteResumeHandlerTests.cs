using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ResumeCreatorAPI.Features.Resume.DeleteResume;

namespace ResumeCreator.Tests.Handlers
{
    public class DeleteResumeHandlerTests
    {
        private readonly Mock<IDeleteResumeRepository> _mockResumeRepository;
        private readonly DeleteResumeHandler _handler;

        public DeleteResumeHandlerTests()
        {
            _mockResumeRepository = new Mock<IDeleteResumeRepository>();
            _handler = new DeleteResumeHandler(_mockResumeRepository.Object);
        }
        [Fact]
        public async Task Handle_Should_Return_True_When_Resume_Is_Deleted()
        {
            // Arrange
            var resumeId = "12345";
            _mockResumeRepository
                .Setup(repo => repo.DeleteResumeAsync(resumeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var command = new DeleteResumeCommand(resumeId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            _mockResumeRepository.Verify(repo => repo.DeleteResumeAsync(resumeId, It.IsAny<CancellationToken>()), Times.Once);
        }
        [Fact]
        public async Task Handle_Should_Return_False_When_Resume_Does_Not_Exist()
        {
            // Arrange
            var resumeId = "nonexistent";
            _mockResumeRepository
                .Setup(repo => repo.DeleteResumeAsync(resumeId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var command = new DeleteResumeCommand(resumeId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            _mockResumeRepository.Verify(repo => repo.DeleteResumeAsync(resumeId, It.IsAny<CancellationToken>()), Times.Once);



        }
    }
}