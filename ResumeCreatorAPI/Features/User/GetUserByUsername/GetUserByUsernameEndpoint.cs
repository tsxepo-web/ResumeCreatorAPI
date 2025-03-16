using MediatR;

namespace ResumeCreatorAPI.Features.User.GetUserByUsername
{
    public class GetUserByUsernameEndpoint
    {
        public static void MapGetUserByUsernameEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet(
                "api/user/username/{username}", async (string username,  IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetUserByUsernameQuery(username));

                    return response is not null
                    ? Results.Ok(response)
                    : Results.NotFound($"Resume with ID {username} not found.");
                }
            );
        }
    }
}