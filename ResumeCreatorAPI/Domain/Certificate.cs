namespace ResumeCreatorAPI.Domain;

public class Certificate
{
   public string? Name { get; set; }
    public DateTime Date { get; set; }
    public string? Issuer { get; set; }
    public string? Url { get; set; }
}