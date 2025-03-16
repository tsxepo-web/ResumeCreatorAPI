using MediatR;

namespace ResumeCreatorAPI.Features.User.GetUserByEmail
{
    public class GetUserByEmailEndpoint
    {
        public static void MapGetUserByEmailEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet(
                "api/user/{email}", async (string email,  IMediator mediator) =>
                {
                    var response = await mediator.Send(new GetUserByEmailQuery(email));

                    return response is not null
                    ? Results.Ok(response)
                    : Results.NotFound($"Resume with ID {email} not found.");
                }
            );
        }
    }
}