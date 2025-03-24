using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ResumeCreatorAPI.Features.Templates
{
    public class TemplateEndpoinnt
    {
        public static void MapRenderResumeEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost(
                "api/resume/{id}/render/{templateName}", async ([FromRoute] string id, [FromBody] RenderResumeCommand request, IMediator mediator) =>
                {
                    try
                    {
                        var command = new RenderResumeCommand(request.ResumeId, request.TemplateName);
                        var renderedLatex = await mediator.Send(command);
                        return Results.Ok(new { Latex = renderedLatex });
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message, statusCode: 400);
                    }
                }
            );
        }
    }
}