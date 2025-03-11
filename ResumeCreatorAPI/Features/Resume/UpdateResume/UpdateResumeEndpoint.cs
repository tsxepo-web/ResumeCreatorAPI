using MediatR;

namespace ResumeCreatorAPI.Features.Resume.UpdateResume
{
    public class UpdateResumeEndpoint
    {
        public static void MapUpdateResumeEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPut(
                "api/resume/{id}", async (string id, UpdateResumeCommand command, IMediator mediator) =>
                {
                    if (id != command.Id)
                    {
                        return Results.BadRequest("ID in the URL does not match ID in the request body.");
                    }
                    var result = await mediator.Send(command);
                    return result.Success ? Results.Ok(result) : Results.NotFound(result.Message);
                }
            );
        }
    }
}