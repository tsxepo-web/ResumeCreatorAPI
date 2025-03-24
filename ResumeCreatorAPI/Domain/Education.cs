namespace ResumeCreatorAPI.Domain;

public class Education
{
    public string? Institution { get; set; }
    public string? Url { get; set; }
    public string? Area { get; set; }
    public string? StudyType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Score { get; set; }
    public List<string>? Courses { get; set; }
}