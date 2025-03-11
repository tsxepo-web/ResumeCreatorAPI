using MediatR;

namespace ResumeCreatorAPI.Features.Resume.DeleteResume
{
    public class DeleteResumeEndpoint
    {
        public static void MapDeleteResumeEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapDelete(
                "api/resume/{id}", async (string id, ISender sender) =>
                {
                    var result = await sender.Send(new DeleteResumeCommand(id));

                    return result ? Results.NoContent() : Results.NotFound();
                }
            );
        }
    }
}