using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeCreatorAPI.Domain
{
    public class Resume(
        PersonalInfo personalInfo,
        List<Education> educations,
        List<Experience> experiences,
        List<Skill> skills,
        List<Certification> certifications,
        string templateStyle
        )
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public PersonalInfo PersonalInfo { get; set; } = personalInfo ?? throw new ArgumentNullException(nameof(personalInfo));
        public List<Education> Educations { get; set; } = educations ?? [];
        public List<Experience> Experiences { get; set; } = experiences ?? [];
        public List<Skill> Skills { get; set; } = skills ?? [];
        public List<Certification> Certifications { get; set; } = certifications ?? [];
        public string? TemplateStyle { get; set; } = templateStyle ?? throw new ArgumentNullException(nameof(templateStyle));
    }
}