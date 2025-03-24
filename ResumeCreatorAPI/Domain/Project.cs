namespace ResumeCreatorAPI.Domain;

public class Project
{
    public string? Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Description { get; set; }
    public List<string>? Highlights { get; set; }
    public string? Url { get; set; }
}