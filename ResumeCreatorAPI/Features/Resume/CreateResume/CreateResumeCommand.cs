using MediatR;
using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Features.Resume.Commands
{
   public record CreateResumeCommand(
    PersonalInfo PersonalInfo,
    List<Education> Educations,
    List<Skill> Skills,
    List<Experience> Experiences,
    List<Certification> Certifications,
    string TemplateStyle
    ) : IRequest<CreateResumeResponse>;
}