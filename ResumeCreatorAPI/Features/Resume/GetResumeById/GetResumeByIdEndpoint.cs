using MediatR;

namespace ResumeCreatorAPI.Features.Resume.GetResumeById
{
    public class GetResumeByIdEndpoint
    {
        public static void MapGetResumeByIdEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet(
                "api/resume/{id}", async (string id,  IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetResumeByIdQuery(id));

                    return response is not null
                    ? Results.Ok(response)
                    : Results.NotFound($"Resume with ID {id} not found.");
                }
            );
        }
    }
}