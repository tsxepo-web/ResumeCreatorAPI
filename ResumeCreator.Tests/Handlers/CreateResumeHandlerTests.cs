using MongoDB.Bson;
using Moq;
using ResumeCreatorAPI.Domain;
using ResumeCreatorAPI.Features.Resume.Commands;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Infrastructure.Services;

namespace ResumeCreator.Tests.Handlers
{
    public class CreateResumeHandlerTests
    {
        private readonly Mock<IResumeRepository> _mockRepository;
        private readonly Mock<ITemplateService> _mockTemplateService;
        private readonly CreateResumeHandler _handler;

        public CreateResumeHandlerTests()
        {
            _mockRepository = new Mock<IResumeRepository>();
            _mockTemplateService = new Mock<ITemplateService>();
            _handler = new CreateResumeHandler(_mockRepository.Object, _mockTemplateService.Object);
        }

        [Fact]
        public async Task Handle_Should_CreateResume_and_ReturnResponse()
        {
            var request = new CreateResumeCommand(
                new PersonalInfo { Name = "John Doe" },
                new List<Education>(),
                new List<Skill>(),
                new List<Experience>(),
                new List<Certification>(),
                "Modern"
            );

            _mockTemplateService
                .Setup(service => service.GenerateTemplate(It.IsAny<string>()))
                .Returns("GeneratedTemplate");

            Resume? savedResume = null;
            _mockRepository
                .Setup(repo => repo.AddResumeAsync(It.IsAny<Resume>(), It.IsAny<CancellationToken>()))
                .Callback<Resume, CancellationToken>((resume, _) =>
                {
                    resume.Id = ObjectId.GenerateNewId().ToString();
                    savedResume = resume;
                })
                .Returns(Task.CompletedTask);

            var result = await _handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.NotNull(result.ResumeId);
            Assert.NotNull(savedResume);
            Assert.NotNull(savedResume?.Id);
            Assert.Equal("GeneratedTemplate", savedResume?.TemplateStyle);
            _mockRepository.Verify(r => r.AddResumeAsync(It.IsAny<Resume>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockTemplateService.Verify(s => s.GenerateTemplate(It.IsAny<string>()), Times.Once);
        }
    }
}