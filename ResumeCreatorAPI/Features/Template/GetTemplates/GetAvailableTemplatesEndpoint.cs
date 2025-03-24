using MediatR;
using ResumeCreatorAPI.Features.Templates.GetTemplates;

namespace ResumeCreatorAPI.Features.Template.GetTemplates;

public class GetAvailableTemplatesEndpoint
{
    public static void MapGetAvailableTemplateEndpoint(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet(
                "api/resume/templates", async (string? templateName, IMediator mediator) =>
                {
                    try
                    {
                        var query = new GetAvailableTemplatesQuery(templateName!);
                        var templates = await mediator.Send(query);
                        return Results.Ok(templates);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem(ex.Message, statusCode: 400);
                    }
                }
            );
        }
}