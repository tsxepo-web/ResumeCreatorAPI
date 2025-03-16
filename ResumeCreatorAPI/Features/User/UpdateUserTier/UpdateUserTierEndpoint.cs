using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ResumeCreatorAPI.Features.User.UpdateUserTier
{
    public class UpdateUserTierEndpoint
    {
        public static void MapUpdateUserTierEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPut(
                "api/user/tier/", async ([FromBody] UpdateUserTierCommand request,  IMediator mediator) =>
                {
                    var response = await mediator.Send(request);

                    return response
                    ? Results.Ok("User tier updatted successfully.")
                    : Results.NotFound($"Resume with ID {request.Email} not found.");
                }
            );
        }
    }
}