using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ResumeCreatorAPI.Domain;

public class Resume
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public Basics? Basics { get; set; }
    public List<Work>? Work { get; set; }
    public List<Volunteer>? Volunteer { get; set; }
    public List<Education>? Education { get; set; }
    public List<Award>? Awards { get; set; }
    public List<Certificate>? Certificates { get; set; }
    public List<Publication>? Publications { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<Languages>? Languages { get; set; }
    public List<Interest>? Interests { get; set; }
    public List<References>? References { get; set; }
    public List<Project>? Projects { get; set; }

    public Resume()
    {
        Work = [];
        Volunteer = [];
        Education = [];
        Awards = [];
        Certificates = [];
        Publications = [];
        Skills = [];
        Languages = [];
        Interests = [];
        References = [];
        Projects = [];
    }
}
