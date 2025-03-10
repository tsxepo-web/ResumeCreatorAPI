using MediatR;

namespace ResumeCreatorAPI.Features.Resume.GetResume
{
    public class GetAllResumesEndpoint
    {
        public static void MapGetAllResumeEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet(
                "api/resume", async (IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetAllResumesQuery());
                    return Results.Ok(response);
                }
            );
        }
    }
}