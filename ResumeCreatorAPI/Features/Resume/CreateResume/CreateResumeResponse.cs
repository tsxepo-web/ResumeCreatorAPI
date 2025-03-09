

namespace ResumeCreatorAPI.Features.Resume.Commands
{
    public interface ICreateResumeResponse
    {
        string ResumeId { get; init; }

        void Deconstruct(out string ResumeId);
        bool Equals(object? obj);
        bool Equals(CreateResumeResponse? other);
        int GetHashCode();
        string ToString();
    }

    public record CreateResumeResponse(string ResumeId) : ICreateResumeResponse;
}