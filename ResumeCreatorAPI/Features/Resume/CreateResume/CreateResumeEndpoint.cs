using MediatR;
using ResumeCreatorAPI.Features.Resume.Commands;

namespace ResumeCreatorAPI.Features.Resume
{
    public class CreateResumeEndpoint
    {
        public static void MapCreateResumeEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(
                "api/resume",
                async (CreateResumeRequest request, ISender sender) =>
                {
                    var response = await sender.Send(request);
                    return Results.Ok(response);
                }
            );
        }

    }
}