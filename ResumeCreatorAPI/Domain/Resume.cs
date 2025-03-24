using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeCreatorAPI.Domain
{
    public class Resume
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public PersonalInfo? PersonalInfo { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Certification> Certifications { get; set; }
        public string TemplateStyle { get; set; }

        public Resume(
            PersonalInfo? personalInfo,
            List<Education>? educations,
            List<Experience>? experiences,
            List<Skill>? skills,
            List<Certification>? certifications,
            string templateStyle = "classic"
        )
        {
            PersonalInfo = personalInfo;
            Educations = educations ?? [];
            Experiences = experiences ?? [];
            Skills = skills ?? [];
            Certifications = certifications ?? [];
            TemplateStyle = templateStyle;
        }
    }
}
