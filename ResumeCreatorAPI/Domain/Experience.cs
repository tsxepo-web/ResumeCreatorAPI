namespace ResumeCreatorAPI.Domain
{
    public class Experience
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Responsibilities { get; set; }
    }
}