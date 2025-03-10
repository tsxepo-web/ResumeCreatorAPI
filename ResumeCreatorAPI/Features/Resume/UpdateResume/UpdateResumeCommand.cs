using MediatR;
using ResumeCreatorAPI.Domain;

namespace ResumeCreatorAPI.Features.Resume.UpdateResume
{
    public record UpdateResumeCommand(
        string Id,
        PersonalInfo PersonalInfo,
        List<Education> Educations,
        List<Experience> Experiences,
        List<Skill> Skills,
        List<Certification> Certifications,
        string TemplateStyle
    ) : IRequest<UpdateResumeResponse>;
   
}