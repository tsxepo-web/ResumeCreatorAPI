using MediatR;

namespace ResumeCreatorAPI.Features.User.CreateUser
{
    public class CreateUserEndpoint
    {
        public static void MapCreateUserEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(
                "api/user",
                async (CreateUserCommand request, ISender sender) =>
                {
                    var response = await sender.Send(request);
                    return Results.Ok(response);
                }
            );
        }
    }
}